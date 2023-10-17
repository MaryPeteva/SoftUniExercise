namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void DatabaseIsInitializedCorrectly()
        {
            Person pers = new Person(1, "Pesho");
            Database database = new Database(pers);
            Assert.IsNotNull(database);
        }

        [Test]
        public void CountReturnsCorrectCount()
        {
            Person pers = new Person(1, "Pesho");
            Database database = new Database(pers);
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void AddAddsNewPerson()
        {
            Database database = new Database();
            Person pers = new Person(1, "Pesho");
            database.Add(pers);
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void RemoveRemovesLastElement() 
        {
            Person[] persons = new Person[5];
            for (int i = 0; i < 5; i++)
            {
                Person person = new Person(i, $"Person{i}");
                persons[i] = person;
            }
            Database db = new Database(persons);
            db.Remove();
            Assert.Throws<InvalidOperationException>(() => db.FindById(4), "No user is present by this ID!");
            Assert.AreEqual(4, db.Count);
        }
        [Test]

        public void RemoveThrowsExeptionWhenDBIsEmpty()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]

        public void AddRangeAddsNewElement()
        {
            Database database = new Database();
            Person pers = new Person(1, "Pesho");
            database.Add(pers);
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void AddThrowsExeptionWhenElementsMoreThan16()
        {
            Database database = new Database();
            List<Person> persons = new List<Person>();
            for (int i = 1; i <= 16; i++)
            {
                Person person = new Person(i, $"Person{i}");
                persons.Add(person);
            }
            for (int i = 0; i < 16; i++)
            {
                database.Add(persons[i]);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17,"person17")), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddRangeThrowsExeptionIfProvidedArrMoreThan16() 
        {
            Person[] persons = new Person[17];
            for (int i = 1; i < 17; i++)
            {
                Person person = new Person(i, $"Person{i}");
                persons[i] = person;
            }
            Assert.Throws<ArgumentException>(() => new Database(persons), "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void AddThrowsExeptionWhenPersonNameDublicates() 
        {
            Database database = new Database();
            Person pers = new Person(1, "Pesho");
            database.Add(pers);
            Assert.Throws<InvalidOperationException>(()=> database.Add(pers), "There is already user with this username!");

        }

        [Test]
        public void AddThrowsExeptionWhenPersonIdDublicates()
        {
            Database database = new Database();
            Person pers = new Person(1, "Pesho");
            database.Add(pers);
            Assert.Throws<InvalidOperationException>(() => database.Add(pers), "There is already user with this Id!");

        }

        [Test]
        public void FindByIDReturnsCorrect() 
        {
            Person[] persons = new Person[12];
            for (int i = 0; i < 12; i++)
            {
                Person person = new Person(i, $"Person{i}");
                persons[i] = person;
            }
            Database db = new Database(persons);
            Person p = new Person(10, "Person10");
            Assert.AreEqual(p.Id, db.FindById(10).Id);
            Assert.AreEqual(p.UserName, db.FindById(10).UserName);
        }

        [Test]
        public void FindByUserNameReturnsCorrect()
        {
            Person[] persons = new Person[12];
            for (int i = 0; i < 12; i++)
            {
                Person person = new Person(i, $"Person{i}");
                persons[i] = person;
            }
            Database db = new Database(persons);
            Person p = new Person(10, "Person10");
            Assert.AreEqual(p.Id, db.FindByUsername("Person10").Id);
            Assert.AreEqual(p.UserName, db.FindByUsername("Person10").UserName);
        }

        [Test]
        public void FindByIdThrowsExeptionWhenIdNotInDB() 
        {
            Person[] persons = new Person[12];
            for (int i = 0; i < 12; i++)
            {
                Person person = new Person(i, $"Person{i}");
                persons[i] = person;
            }
            Database db = new Database(persons);
            Assert.Throws<InvalidOperationException>(() =>db.FindById(15), "No user is present by this ID!");

        }

        [Test]
        public void FindByIdThrowsExeptionWhenIdNegative()
        {
            Person[] persons = new Person[12];
            for (int i = 0; i < 12; i++)
            {
                Person person = new Person(i, $"Person{i}");
                persons[i] = person;
            }
            Database db = new Database(persons);
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1), "Id should be a positive number!");

        }

        [Test]
        public void FindByUserNameThrowsExeptionWhenNameNotInDB()
        {
            Person[] persons = new Person[12];
            for (int i = 0; i < 12; i++)
            {
                Person person = new Person(i, $"Person{i}");
                persons[i] = person;
            }
            Database db = new Database(persons);
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Pesho"), "No user is present by this username!");

        }


        [Test]
        public void FindByUserNameThrowsExeptionWhenNameNull()
        {
            Person[] persons = new Person[12];
            for (int i = 0; i < 12; i++)
            {
                Person person = new Person(i, $"Person{i}");
                persons[i] = person;
            }
            Database db = new Database(persons);
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null), "Username parameter is null!");

        }

    }
}