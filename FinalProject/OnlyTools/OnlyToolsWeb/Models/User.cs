using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static OnlyToolsWeb.Models.Utilities.Constants;

namespace OnlyToolsWeb.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(UsernameLen)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(UserFirstNameLen)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(UserLastNameLen)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        //it will be moved
        //static bool IsValidEmail(string email)
        //{
        //    // Regular expression pattern for validating email address format
        //    string pattern = @"^[\w.-]+@[a-zA-Z\d.-]+\.[a-zA-Z]{2,4}$";

        //    // Create a Regex object with the pattern
        //    Regex regex = new Regex(pattern);

        //    // Check if the email address matches the pattern
        //    return regex.IsMatch(email);
        //}
        [Required]
        public string Password { get; set; }
        //chack for required "to have capital, small letter, number and specia; symbol",encript password
        //public static bool IsValidPassword(string password)
        //{
        //    string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()-+_{}[\]:;<>,.?/~]).{8,}$";
        //    Regex regex = new Regex(pattern);
        //    return regex.IsMatch(password);
        //}
        // Generate Salt and Hash Password
        //string password = "user_password";
        //string salt = BCrypt.Net.BCrypt.GenerateSalt(12); // Generate a salt with work factor 12
        //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);//password is hashed
        //Console.WriteLine(hashedPassword);// login attempt provides "input"
        //string input = Console.ReadLine();
        //Console.WriteLine(BCrypt.Net.BCrypt.Verify(input, hashedPassword));//this will  be returned in password check
        public string? ProfilePictureUrl { get; set; }
        public virtual ICollection<UserOwnedTool>? UserTools { get; set; }
        public virtual ICollection<UserRentedTool>? UserRentedTools { get; set; }
        public virtual ICollection<UserPublishedTip>? UserTips { get; set; }
        public virtual ICollection<Favourites>? Favourites { get; set; }
    }
}
