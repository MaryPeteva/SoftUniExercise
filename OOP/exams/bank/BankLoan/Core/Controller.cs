using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Core.Contracts;
using BankLoan.Repositories;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private BankRepository banks;
        private LoanRepository loans;

        public Controller()
        {
            this.banks = new BankRepository();
            this.loans = new LoanRepository();
        }
        public string AddBank(string bankTypeName, string name)
        {
            IBank tempBank = null;
            switch (bankTypeName)
            {
                case "BranchBank":
                    tempBank = new BranchBank(name);
                    banks.AddModel(tempBank);
                    return string.Format(OutputMessages.BankSuccessfullyAdded, tempBank.GetType().Name);
                case "CentralBank":
                    tempBank = new CentralBank(name);
                    banks.AddModel(tempBank);
                    return string.Format(OutputMessages.BankSuccessfullyAdded, tempBank.GetType().Name);
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.BankTypeInvalid));
            }
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IClient tempClient = null;
            IBank tempBank = banks.Models.FirstOrDefault(b => b.Name == bankName);

            switch (clientTypeName)
            {
                case "Adult":
                    tempClient = new Adult(clientName, id, income);
                    if (tempBank.GetType().Name != "CentralBank")
                    {
                        throw new ArgumentException(string.Format(OutputMessages.UnsuitableBank));
                    }
                    tempBank.AddClient(tempClient);
                    return string.Format(OutputMessages.ClientAddedSuccessfully, tempClient.GetType().Name, bankName);
                case "Student":
                    tempClient = new Student(clientName, id, income);
                    if (tempBank.GetType().Name != "BranchBank")
                    {
                        throw new ArgumentException(string.Format(OutputMessages.UnsuitableBank));
                    }
                    tempBank.AddClient(tempClient);
                    return string.Format(OutputMessages.ClientAddedSuccessfully, tempClient.GetType().Name, bankName);
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.ClientTypeInvalid));
            }
        }

        public string AddLoan(string loanTypeName)
        {
            ILoan tempLoan = null;
            switch (loanTypeName)
            {
                case "StudentLoan":
                    tempLoan = new StudentLoan();
                    loans.AddModel(tempLoan);
                    return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
                case "MortgageLoan":
                    tempLoan = new MortgageLoan();
                    loans.AddModel(tempLoan);
                    return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType));
            }
        }

        public string FinalCalculation(string bankName)
        {
            IBank tempBank = banks.Models.FirstOrDefault(b => b.Name == bankName);
            double sumClientsIncome = tempBank.Clients.Sum(c => c.Income);
            double amount = 0;
            foreach (ILoan loan in tempBank.Loans)
            {
                amount += loan.Amount;
            }
            double totSum = sumClientsIncome + amount;
            return string.Format(OutputMessages.BankFundsCalculated, bankName, totSum);
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            IBank tempBank = banks.Models.FirstOrDefault(b => b.Name == bankName);
            ILoan tempLoan = loans.Models.FirstOrDefault(l => l.GetType().Name == loanTypeName);
            if (tempLoan != null)
            {
                loans.RemoveModel(tempLoan);
                tempBank.AddLoan(tempLoan);
                return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }
        }

        public string Statistics()
        
        {
            StringBuilder message = new StringBuilder();
            foreach (IBank bank in banks.Models)
            {
               
                message.AppendLine(bank.GetStatistics());
            }
            return message.ToString().TrimEnd();
        }

    }
}
