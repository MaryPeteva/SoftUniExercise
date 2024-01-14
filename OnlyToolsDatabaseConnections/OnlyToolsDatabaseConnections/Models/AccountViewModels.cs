using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OnlyToolsWeb.Models
{
    public class AccountViewModels
    {
        public class LoginViewModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public class RegisterViewModel : IValidatableObject
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }

            [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (!IsValidEmail(Email))
                {
                    yield return new ValidationResult("Invalid email!", new[] { nameof(Email) });
                }
            }

            private static bool IsValidEmail(string email)
            {
                string pattern = @"^[\w.-]+@[a-zA-Z\d.-]+\.[a-zA-Z]{2,4}$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(email);
            }
        }
    }
}
