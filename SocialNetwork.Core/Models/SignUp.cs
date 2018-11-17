using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetwork.Core.Models
{
    public class SignUp
    {

        public const string PasswordMismatch = "Passwords don't match";

        public const string DisplayNameExistsMessage = "Display name is already in use";

        [Required]
        public string UserName { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = PasswordMismatch)]
        public string ConfirmPassword { get; set; }

        public string ReturnURL { get; set; }

    }
}
