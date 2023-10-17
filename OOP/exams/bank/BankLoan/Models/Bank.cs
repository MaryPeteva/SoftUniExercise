using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using BankLoan.Utilities.Messages;
using System.Linq;
using System.Text;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private int capacity;
        private List<ILoan> loans;
        private List<IClient> clients;
        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new List<ILoan>();
            clients = new List<IClient>();
        }
        public string Name { get => this.name;
            private set 
            {
                if (string.IsNullOrEmpty(value)) 
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.BankNameNullOrWhiteSpace));
                }
                name = value;
            }
        }

        public int Capacity { get => capacity; private set => capacity = value; }

        public IReadOnlyCollection<ILoan> Loans => loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => clients.AsReadOnly();

        public void AddClient(IClient Client)
        {
            if (capacity < 0) 
            {
                throw new ArgumentException(string.Format("Not enough capacity for this client."));
            }
            this.clients.Add(Client);
            this.capacity--;

        }
        public void RemoveClient(IClient Client)
        {
            this.clients.Remove(Client);
            this.capacity++;
        }

        public void AddLoan(ILoan loan)
        {
            this.loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder mess = new StringBuilder();
            mess.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");
            if (this.clients.Any())
            {
                List<string> names = new List<string>();
                foreach (var client in this.clients) 
                {
                    names.Add(client.Name);
                }
                mess.AppendLine($"Clients: {string.Join(", ", names)}");
            }
            else 
            {
                mess.AppendLine("Clients: none");
            }

            if (this.loans.Any())
            {

                mess.AppendLine($"Loans: {this.loans.Count}, Sum of Rates: {SumRates()}");
            }
            else 
            {
                mess.AppendLine("Loans: 0, Sum of Rates: 0");
            }

            return mess.ToString().TrimEnd();
        }


        public double SumRates()
        {
            return this.loans.Sum(l => l.InterestRate);
        }
    }
}
