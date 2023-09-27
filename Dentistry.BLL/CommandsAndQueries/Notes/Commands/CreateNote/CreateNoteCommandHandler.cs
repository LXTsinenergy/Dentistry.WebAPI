using AutoMapper;
using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Migrations;
using Dentistry.DAL.Repositories.DayRepository;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.DAL.Repositories.NoteRepository;
using Dentistry.Domain.Models;
using MediatR;
using System.ComponentModel;
using System.Threading;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;
        private readonly IDayRepository _dayRepository;
        private readonly IDoctorRepository _doctorRepository;

        public CreateNoteCommandHandler(
            IMapper mapper,
            INoteRepository noteRepository,
            IDayRepository dayRepository,
            IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
            _dayRepository = dayRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var day = await FindDayAsync(request.Date, cancellationToken);
            if (day == null)
            {
                return false;
            }

            var doctor = await FindDoctorAsync(request.DoctorId);
            if (doctor == null)
            {
                return false;
            }

            var note = new Note()
            {
                Workday = day,
                Doctor = doctor,
                AppointmentTime = ConvertToDateTime(request.Date, request.AppointmentTime)
            };

            await AddNote(_noteRepository, note, cancellationToken);
            return true;
        }

        #region Private Methods
        private async Task<Domain.Models.Workday> FindDayAsync(DateOnly date, CancellationToken cancellationToken)
        {
            try
            {
                var day = await _dayRepository.GetByDateAsync(date, cancellationToken);
                return day;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(DayRepository), ex.Message);
            }
        }

        private async Task<Doctor> FindDoctorAsync(int doctorId)
        {
            try
            {
                var doctor = await _doctorRepository.GetByIdAsync(doctorId);
                return doctor;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(DoctorRepository), ex.Message);
            }
        }

        private async Task AddNote(INoteRepository noteRepository, Note note, CancellationToken cancellationToken)
        {
            try
            {
                await _noteRepository.AddAsync(note, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(NoteRepository), ex.Message);
            }
        }

        private DateTime ConvertToDateTime(DateOnly date, TimeOnly time) =>
            new(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second); 
        #endregion
    }
}
