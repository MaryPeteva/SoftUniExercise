using System;
using Telephony.Models.Interfaces;

public class StationaryPhone : ICallable
{
    Validations v = new Validations();
    public string Call(string number)
    {
        if (!v.ValidNumber(number)) 
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Dialing... {number}";
    }
}
