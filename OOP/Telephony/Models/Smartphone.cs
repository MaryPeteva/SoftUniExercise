
using Telephony.Models.Interfaces;


namespace Telephony.Models;

public class Smartphone : ICallable, IBrowsable
{
    Validations v = new Validations();
    public string Browse(string url)
    {
        
        if (!v.ValidURL(url)) 
        {
            throw new ArgumentException("Invalid URL!");
        }

        return $"Browsing: {url}!";
    }

    public string Call(string number)
    {
        if (!v.ValidNumber(number)) 
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Calling... {number}";
    }

    //private bool ValidNumber(string phoneNumber) 
    //{
    //    return phoneNumber.All(c => char.IsDigit(c));
    //}

    //private bool ValidURL(string url) 
    //{
    //    return url.All(c => !char.IsDigit(c));
    //}
}