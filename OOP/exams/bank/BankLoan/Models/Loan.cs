using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Loan : ILoan
    {
        private int interestRate;
        private double amount;
        protected Loan(int interestRate, double amount)
        {
            InterestRate = interestRate;
            Amount = amount;
        }
        public int InterestRate { get=>this.interestRate; private set=> this.interestRate = value; }

        public double Amount { get=>this.amount; private set=>this.amount = value; }
    }
}
