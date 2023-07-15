using System;
using System.Linq;
using System.Reflection;
using System.Text;
using AutomotiveRepairShop;
using NUnit.Framework;

[TestFixture]
public class T000_000
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void RepairShopReportMethod()
    {
        var repairShopArguments = new object[] { 6 };
        var repairShop = CreateObjectInstance(GetType("RepairShop"), repairShopArguments);

        var vehicleArguments1 = new object[] { "5YJSA1CN7DFP12345", 90123, "Overheating issue" };
        var vehicle1 = CreateObjectInstance(GetType("Vehicle"), vehicleArguments1);

        var vehicleArguments2 = new object[] { "JM1GJ1W56F1234567", 120000, "Coolant leakage" };
        var vehicle2 = CreateObjectInstance(GetType("Vehicle"), vehicleArguments2);

        var vehicleArguments3 = new object[] { "2C3CDXAT4CH123456", 95000, "Timing belt failure" };
        var vehicle3 = CreateObjectInstance(GetType("Vehicle"), vehicleArguments3);

        var vehicleArguments4 = new object[] { "WAUZZZ8K9FA123456", 66000, "Cylinder misfire" };
        var vehicle4 = CreateObjectInstance(GetType("Vehicle"), vehicleArguments4);

        var vehicleArguments5 = new object[] { "JTDKB20U993123456", 65000, "Piston damage" };
        var vehicle5 = CreateObjectInstance(GetType("Vehicle"), vehicleArguments5);

        InvokeMethod(repairShop, "AddVehicle", new object[] { vehicle1 });
        InvokeMethod(repairShop, "AddVehicle", new object[] { vehicle2 });
        InvokeMethod(repairShop, "AddVehicle", new object[] { vehicle3 });
        InvokeMethod(repairShop, "AddVehicle", new object[] { vehicle4 });
        InvokeMethod(repairShop, "AddVehicle", new object[] { vehicle5 });

        var actualResult = InvokeMethod(repairShop, "Report", null);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Vehicles in the preparatory:");
        sb.AppendLine("Damage: Overheating issue, Vehicle: 5YJSA1CN7DFP12345 (90123 km)");
        sb.AppendLine("Damage: Coolant leakage, Vehicle: JM1GJ1W56F1234567 (120000 km)");
        sb.AppendLine("Damage: Timing belt failure, Vehicle: 2C3CDXAT4CH123456 (95000 km)");
        sb.AppendLine("Damage: Cylinder misfire, Vehicle: WAUZZZ8K9FA123456 (66000 km)");
        sb.AppendLine("Damage: Piston damage, Vehicle: JTDKB20U993123456 (65000 km)");

        Assert.That(actualResult, Is.EqualTo(sb.ToString().TrimEnd()));
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
            return Activator.CreateInstance(type, parameters);
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