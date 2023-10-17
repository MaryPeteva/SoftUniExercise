using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class Adult : Client
    {
        private const int AdultInterest = 4;
        public Adult(string name, string id, double income) : base(name, id, AdultInterest, income)
        {
        }

        public override void IncreaseInterest()
        {
            //double interestIncrease = this.Income * 0.02;
            int newInterest = Interest + 2;
            UpdateInterest(newInterest);
        }

        protected void UpdateInterest(int newInterest)
        {
            this.Interest = newInterest;
        }
    }
}
