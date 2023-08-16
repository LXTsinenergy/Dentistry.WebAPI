﻿using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetDoctorById
{
    public class GetDoctorByIdQuery : IRequest<Doctor>
    {
        public int Id { get; set; }
    }
}