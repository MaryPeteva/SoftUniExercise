﻿

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName { get; private set; }


        public string LastName { get; private set; }


        public int Age{get; private set;}

        public decimal Salary { get; private set; }


        public void IncreaseSalary(decimal percent)
        {
            if (Age > 30)
            {
                salary += salary * percent / 100;
            }
            else
            {
                salary += salary * percent / 200;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
