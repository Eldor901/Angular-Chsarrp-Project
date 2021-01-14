using System;
using System.ComponentModel.DataAnnotations;

namespace _.Dtos
{
    public class UserRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(Int32.MaxValue, MinimumLength = 4, ErrorMessage = "minim length 4")]
        public string Password { get; set; }
    }
}