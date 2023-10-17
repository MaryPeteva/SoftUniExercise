namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void DataBaseShouldBeInitializedWithArrauOf16Integers() 
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Database database = new Database(nums);
            Assert.AreEqual(nums, database.Fetch());
        }

        [Test]
        public void DataBaseCanContainOnly16IntegersIfMoreAreAddedWillThrowExeption()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};
            Database database = new Database(nums);
            Assert.Throws<InvalidOperationException>(() => database.Add(17), "Array's capacity must be exactly 16 integers!");
            
        }

        [Test]
        public void AddAddsNewIntInNextOpenCell() 
        {
            Database database = new Database(1);
            database.Add(2);
            int[] nums = { 1, 2, };
            Assert.AreEqual(nums, database.Fetch());
        }

        [Test]
        public void RemoveRemovesTheLastElement() 
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int[] nums2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
            Database database = new Database(nums);
            database.Remove();
            Assert.AreEqual(nums2, database.Fetch());
        }

        [Test]
        public void RemoveThrowsExeptionWhenCollectionIsEmpty() 
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() =>database.Remove(), "The collection is empty!");
        }

        [Test]
        public void CountReturnsCorrectCount() 
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            Database database = new Database(nums);
            Assert.AreEqual(5, database.Count);
        }
    }
}
