using Telephony.Models.Interfaces;

public class Validations 
{
    public bool ValidNumber(string phoneNumber)
    {
        return phoneNumber.All(c => char.IsDigit(c));
    }

    public bool ValidURL(string url)
    {
        return url.All(c => !char.IsDigit(c));
    }
}