﻿using AutoMapper;
using Dentistry.Domain.DTO.Day;
using Dentistry.Domain.DTO.DoctorDTO;
using Dentistry.Domain.DTO.Note;
using Dentistry.Domain.DTO.Review;
using Dentistry.Domain.DTO.User;
using Dentistry.Domain.DTO.UserDTO.UserDTO;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region CreateMap
            CreateMap<UserRegisterDTO, User>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<DoctorCreationDTO, Doctor>();
            CreateMap<WorkdayCreationDTO, Workday>();
            CreateMap<NoteCreationDTO, Note>();
            CreateMap<ReviewCreationDTO, Review>(); 
            #endregion
        }
    }
}
