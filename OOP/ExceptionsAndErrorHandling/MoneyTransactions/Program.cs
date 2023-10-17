public class Program
{
    static void Main()
    {
        string[] accInput = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
        List<Account> accs = new List<Account>();
        for (int i = 0; i < accInput.Length; i++)
        {
            string[] tokens = accInput[i].Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int accn = int.Parse(tokens[0]);
            double amount = double.Parse(tokens[1]);
            Account temp = new Account(accn, amount);
            accs.Add(temp);
        }

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = tokens[0];
            int accNum = int.Parse(tokens[1]);
            double amount = double.Parse(tokens[2]);
            Account foundAccount = accs.Find(account => account.AccNum == accNum);
            try
            {
                switch (command)
                {
                    case "Deposit":
                        if (CheckAcc(foundAccount))
                        {
                            foundAccount.Deposit(amount);
                            Console.WriteLine(foundAccount.ToString());
                        }
                        break;
                    case "Withdraw":
                        if (CheckAcc(foundAccount))
                        {
                            foundAccount.Withdraw(amount);
                            Console.WriteLine(foundAccount.ToString());
                        }
                        break;
                    default:
                        throw new ArgumentException("Invalid command!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                Console.WriteLine("Enter another command");
            }
        }
    }

    private static bool CheckAcc(Account acc)
    {
        if (acc == null)
        {
            throw new NullReferenceException("Invalid account!");
        }
        else
        {
            return true;
        }
    }

}


public class Account
{
    private int accNum;
    private double amount;
    public Account(int numIn, double amIn)
    {
        this.AccNum = numIn;
        this.Amount = amIn;
    }

    public int AccNum { get => this.accNum; private set => this.accNum = value; }
    public double Amount { get => this.amount; private set => this.amount = value; }

    public void Withdraw(double wAm)
    {
        if (this.Amount - wAm < 0)
        {
            throw new ArgumentException("Insufficient balance!");
        }
        this.Amount -= wAm;
    }

    public void Deposit(double depAm)
    {
        this.Amount += depAm;
    }
    public override string ToString()
    {
        return $"Account {this.AccNum} has new balance: {this.Amount:F2}";
    }
}