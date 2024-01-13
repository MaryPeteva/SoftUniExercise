using BCrypt.Net;
using System.Text.RegularExpressions;

public class Program
{
    public static bool IsValidPassword(string password)
    {
        // Define the regular expression pattern
        string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()-+_{}[\]:;<>,.?/~]).{8,}$";

        // Create a Regex object with the pattern
        Regex regex = new Regex(pattern);

        // Check if the password matches the pattern
        return regex.IsMatch(password);
    }

    public static void Main(string[] args)
    {
        // Test the IsValidPassword method with sample passwords
        string[] passwords = { "Password1!", "test123", "SamplePassword@", "Password1234" };

        foreach (var password in passwords)
        {
            Console.WriteLine($"Password: {password} - IsValid: {IsValidPassword(password)}");
        }
    }
}
