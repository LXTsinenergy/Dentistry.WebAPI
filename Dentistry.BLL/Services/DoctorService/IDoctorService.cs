﻿using Dentistry.Domain.DTO.Doctor;
using Dentistry.Domain.DTO.DoctorDTO;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<bool> CreateDoctorAsync(DoctorCreationDTO doctorDTO, byte[] passwordSalt);
        Task<bool> DeleteDoctorAsync(Doctor doctor);
        Task<bool> UpdateDoctorAsync(Doctor doctor, DoctorUpdateDTO updateDTO);

        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<Doctor?> GetDoctorByIdAsync(int id);

        Task<bool> PhoneIsRegistered(string phoneNumber);
        Task<bool> EmailIsRegistered(string email);
        Task<bool> DoctorIsExists(int id);
    }
}
