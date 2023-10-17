using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BankLoan;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

public class Tests_002_000_002
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void ValidateExampleData()
    {
        var controller = CreateObjectInstance(GetType("Controller"));

        StringBuilder sb = new StringBuilder();

        var methodArgs1 = new object[] { "BranchBank", "DSKBank" };
        sb.AppendLine($"{InvokeMethod(controller, "AddBank", methodArgs1)}");

        var methodArgs3 = new object[] { "CentralBank", "Fibank" };
        sb.AppendLine($"{InvokeMethod(controller, "AddBank", methodArgs3)}");

        var methodArgs4 = new object[] { "StudentLoan" };
        var methodArgs5 = new object[] { "MortgageLoan" };

        sb.AppendLine($"{InvokeMethod(controller, "AddLoan", methodArgs4)}");
        sb.AppendLine($"{InvokeMethod(controller, "AddLoan", methodArgs5)}");
        sb.AppendLine($"{InvokeMethod(controller, "AddLoan", methodArgs5)}");

        var methodArgs6 = new object[] { "DSKBank", "StudentLoan" };
        sb.AppendLine($"{InvokeMethod(controller, "ReturnLoan", methodArgs6)}");
        var methodArgs9 = new object[] { "Fibank", "StudentLoan" };
        sb.AppendLine($"{InvokeMethod(controller, "ReturnLoan", methodArgs9)}");
        var methodArgs2 = new object[] { "Fibank", "MortgageLoan" };
        sb.AppendLine($"{InvokeMethod(controller, "ReturnLoan", methodArgs2)}");

        var methodArgs10 = new object[] { "Fibank", "Student", "Maria", "54TAF433", 346.70 };
        sb.AppendLine($"{InvokeMethod(controller, "AddClient", methodArgs10)}");

        var methodArgs11 = new object[] { "Fibank", "Adult", "Peter", "65GTTHA134  ", 5643.10 };
        sb.AppendLine($"{InvokeMethod(controller, "AddClient", methodArgs11)}");

        var methodArgs13 = new object[] { "Fibank" };
        sb.AppendLine($"{InvokeMethod(controller, "FinalCalculation", methodArgs13)}");

        sb.AppendLine($"{InvokeMethod(controller, "Statistics", default)}");

        StringBuilder sb2 = new StringBuilder();

        sb2.AppendLine("BranchBank is successfully added.");
        sb2.AppendLine("CentralBank is successfully added.");
        sb2.AppendLine("StudentLoan is successfully added.");
        sb2.AppendLine("MortgageLoan is successfully added.");
        sb2.AppendLine("MortgageLoan is successfully added.");
        sb2.AppendLine("StudentLoan successfully added to DSKBank.");
        sb2.AppendLine("Loan of type StudentLoan is missing.");
        sb2.AppendLine("MortgageLoan successfully added to Fibank.");
        sb2.AppendLine("Unsuitable bank.");
        sb2.AppendLine("Adult successfully added to Fibank.");
        sb2.AppendLine("The funds of bank Fibank are 55643.10.");
        sb2.AppendLine("Name: DSKBank, Type: BranchBank");
        sb2.AppendLine("Clients: none");
        sb2.AppendLine("Loans: 1, Sum of Rates: 1");
        sb2.AppendLine("Name: Fibank, Type: CentralBank");
        sb2.AppendLine("Clients: Peter");
        sb2.AppendLine("Loans: 1, Sum of Rates: 3");

        var expectedResult = sb.ToString().TrimEnd();
        var actualResult = sb2.ToString().TrimEnd();

        Assert.AreEqual(expectedResult, actualResult);
    }

    private static object InvokeMethod(object obj, string methodName, object[] parameters)
    {
        try
        {
            var result = obj.GetType()
                .GetMethod(methodName)
                .Invoke(obj, parameters);

            return result;
        }
        catch (TargetInvocationException e)
        {
            return e.InnerException.Message;
        }
    }

    private static object CreateObjectInstance(Type type, params object[] parameters)
    {
        try
        {
            var desiredConstructor = type.GetConstructors()
                .FirstOrDefault(x => x.GetParameters().Any());

            if (desiredConstructor == null)
            {
                return Activator.CreateInstance(type, parameters);
            }

            var instances = new List<object>();

            foreach (var parameterInfo in desiredConstructor.GetParameters())
            {
                var currentInstance = Activator.CreateInstance(GetType(parameterInfo.Name.Substring(1)));

                instances.Add(currentInstance);
            }

            return Activator.CreateInstance(type, instances.ToArray());
        }
        catch (TargetInvocationException e)
        {
            return e.InnerException.Message;
        }
    }

    private static Type GetType(string name)
    {
        var type = ProjectAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name.Contains(name));

        return type;
    }
}