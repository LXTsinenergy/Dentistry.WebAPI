﻿using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.Models
{
    public class Review : DoctorData
    {
        [Required]
        public string Text { get; set; }

        public DateTime DateOfReview { get; set; }
    }
}
