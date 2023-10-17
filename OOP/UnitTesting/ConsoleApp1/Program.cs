using System;
using System.Linq;

namespace ExtendedDatabase
{

    public class Database
    {
        public static void Main()
        {
            Person[] persons = new Person[12];
            for (int i = 0; i < 12; i++)
            {
                Person person = new Person(i, $"Person{i}");
                persons[i] = person;
            }
            Database db = new Database(persons);
            Person pp = db.FindById(10);
            ;

        }

        private Person[] persons;

        private int count;

        public Database(params Person[] persons)
        {
            this.persons = new Person[16];
            AddRange(persons);
        }

        public int Count
        {
            get { return count; }
        }

        private void AddRange(Person[] data)
        {
            if (data.Length > 16)
            {
                throw new ArgumentException("Provided data length should be in range [0..16]!");
            }

            for (int i = 0; i < data.Length; i++)
            {
                this.Add(data[i]);
            }

            this.count = data.Length;
        }

        public void Add(Person person)
        {
            if (this.count == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            if (persons.Any(p => p?.UserName == person.UserName))
            {
                throw new InvalidOperationException("There is already user with this username!");
            }

            if (persons.Any(p => p?.Id == person.Id))
            {
                throw new InvalidOperationException("There is already user with this Id!");
            }

            this.persons[this.count] = person;
            this.count++;
        }

        public void Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException();
            }

            this.count--;
            this.persons[this.count] = null;
        }

        public Person FindByUsername(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Username parameter is null!");
            }

            if (this.persons.Any(p => p?.UserName == name) == false)
            {
                throw new InvalidOperationException("No user is present by this username!");
            }

            Person person = this.persons.First(p => p.UserName == name);
            return person;
        }


        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id should be a positive number!");
            }

            if (this.persons.Any(p => p?.Id == id) == false)
            {
                throw new InvalidOperationException("No user is present by this ID!");
            }

            Person person = this.persons.First(p => p.Id == id);
            return person;
        }
    }
}

public class Person
{
    private long id;
    private string userName;

    public Person(long id, string userName)
    {
        this.Id = id;
        this.UserName = userName;
    }

    public string UserName
    {
        get { return userName; }
        private set { userName = value; }
    }

    public long Id
    {
        get { return id; }
        private set { id = value; }
    }
}