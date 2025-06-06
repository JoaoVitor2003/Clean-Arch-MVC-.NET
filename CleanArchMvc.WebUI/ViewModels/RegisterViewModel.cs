﻿using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

        public string ConfirmPassword { get; set; }
    }
}
