﻿using BankLoan.Models.Contracts;
using System;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models
{
    public abstract class Client : IClient
    {
        private string name;
        private string id;
        private int interest;
        private double income;
        protected Client(string name, string id, int interest, double income) 
        { 
            Name = name;
            Id = id;
            Interest = interest;
            Income = income;
        }
        public string Name { get=>name; 
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ClientNameNullOrWhitespace));
                }
                name = value;
            }
        }

        public string Id { get=>id;
            private set 
            {
                if (string.IsNullOrEmpty(value)) 
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ClientIdNullOrWhitespace));
                }
                id = value;
            }
        }


        public int Interest { get=>interest;
            protected set 
            {
                interest = value;
            }
        }

        public double Income { get=>income;
            private set 
            {
                if (value <= 0) 
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ClientIncomeBelowZero));
                }
                income = value;
            }
        }

        public abstract void IncreaseInterest();

    }
}
