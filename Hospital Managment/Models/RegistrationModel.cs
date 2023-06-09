﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Managment.Models
{
    public class RegistrationModel
    {
        
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserRole { get; set; }

        [Required]
        public string IsActive { get; set; }
       
    }
}
