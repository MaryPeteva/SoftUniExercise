using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class Student : Client
    {
        private const int StudentInterest = 2;
        public Student(string name, string id, double income) : base(name, id, StudentInterest, income)
        {
        }

        public override void IncreaseInterest()
        {
            //double interestIncrease = this.Income * 0.01;

            int newInterest = Interest + 1;
            UpdateInterest(newInterest);
        }

        protected void UpdateInterest(int newInterest)
        {
            this.Interest = newInterest;
        }
    }
}
