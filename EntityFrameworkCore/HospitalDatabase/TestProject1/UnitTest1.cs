using System;
using System.Linq;
using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;

using P01_HospitalDatabase.Data.Models;

[TestFixture]
public class Test_001_Open
{
    [Test]
    public void ValidatePatientEntity()
    {
        var patientType = typeof(Patient);

        AssertPropertyIsOfType(patientType, "PatientId", typeof(int));
        AssertPropertyIsOfType(patientType, "FirstName", typeof(string));
        AssertPropertyIsOfType(patientType, "LastName", typeof(string));
        AssertPropertyIsOfType(patientType, "Email", typeof(string));
        AssertPropertyIsOfType(patientType, "Address", typeof(string));
        AssertPropertyIsOfType(patientType, "HasInsurance", typeof(bool));

        AssertCollectionIsOfType(patientType, "Visitations", typeof(ICollection<Visitation>));
        AssertCollectionIsOfType(patientType, "Diagnoses", typeof(ICollection<Diagnose>));
    }

    public static PropertyInfo GetPropertyByName(Type type, string propName)
    {
        var properties = type.GetProperties();

        var firstOrDefault = properties.FirstOrDefault(p => p.Name == propName);
        return firstOrDefault;
    }

    public static void AssertPropertyIsOfType(Type type, string propertyName, Type expectedType)
    {
        var property = GetPropertyByName(type, propertyName);
        Assert.IsNotNull(property, $"{propertyName} property not found.");

        var errorMessage = string.Format("{0} property is not {1}!", property.Name, expectedType);
        Assert.That(property.PropertyType, Is.EqualTo(expectedType), errorMessage);
    }

    public static void AssertCollectionIsOfType(Type type, string propertyName, Type collectionType)
    {
        var ordersProperty = GetPropertyByName(type, propertyName);

        var errorMessage = string.Format("{0} property does not exist!", propertyName);

        Assert.IsNotNull(ordersProperty, errorMessage);

        Assert.That(collectionType.IsAssignableFrom(ordersProperty.PropertyType));
    }
}