﻿using System.ComponentModel.DataAnnotations;

namespace KNdatabase.Models.User
{
    public class UserRegistrationVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]

        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirm password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
