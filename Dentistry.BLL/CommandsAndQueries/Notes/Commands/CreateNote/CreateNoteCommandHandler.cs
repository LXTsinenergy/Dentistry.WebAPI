using AutoMapper;
using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.DAL.Repositories.NoteRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;
        private readonly IDoctorRepository _doctorRepository;

        public CreateNoteCommandHandler(
            IMapper mapper,
            INoteRepository noteRepository,
            IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var doctor = await FindDoctorAsync(request.DoctorId);
            if (doctor == null)
            {
                return false;
            }

            var note = new Note()
            {
                Doctor = doctor,
                DoctorId = request.DoctorId,
                AppointmentTime = ConvertToDateTime(request.Date, request.AppointmentTime)
            };

            await AddNote(_noteRepository, note, cancellationToken);
            return true;
        }

        #region Private Methods
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
