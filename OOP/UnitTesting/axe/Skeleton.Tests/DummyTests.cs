using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            Dummy dummy = new Dummy(10, 10);
            Assert.AreEqual(10, dummy.Health);
        }

        [Test]
        public void TakeAttackShoudDecreaseHealth()
        {
            Dummy dummy = new Dummy(100, 100);
            dummy.TakeAttack(50);
            Assert.AreEqual(50, dummy.Health);
        }

        [Test]
        public void TakeAttackShoudThrowExeptionIfDummyIsDead()
        {
            Dummy dummy = new Dummy(100, 100);
            dummy.TakeAttack(50);
            dummy.TakeAttack(50);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(50), "Dummy is dead.");
        }

        [Test]

        public void GiveExperienceShouldReturnCurrentExperianceIfDummyIsDead() 
        {
            Dummy dummy = new Dummy(100, 100);
            dummy.TakeAttack(50);
            dummy.TakeAttack(50);
            Assert.AreEqual(100, dummy.GiveExperience());
        }

        [Test]
        public void GiveExperienceShouldThrowExeptionIfDummyIsNotDead()
        {
            Dummy dummy = new Dummy(100, 100);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Target is not dead.");
        }

        [Test]

        public void IsDeadShoudCheckIfHealthIsBelowOrEqualZero() 
        {
            Dummy dummy = new Dummy(50, 100);
            dummy.TakeAttack(50);
            Assert.IsTrue(dummy.IsDead());
        }
    }
}