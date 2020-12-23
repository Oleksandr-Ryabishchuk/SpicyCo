﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Dtos
{
    public class UserForRegisterDto
    {
        [Required] public string Username { get; set; }

        [Required] public string Gender { get; set; }     

        [Required] public DateTime DateOfBirth { get; set; }

        [Required] public string Interests { get; set; }

        [Required] public string City { get; set; }

        [Required] public string Country { get; set; }
       
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
        public string Password { get; set; }
    }
}
