using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    public class AxeTests
    {
        [Test]
        public void AxeIsInitializedWithAttackPoints() 
        {
            Axe axe = new Axe(10,10);
            Assert.AreEqual(axe.AttackPoints, 10);
        }

        [Test]
        public void AxeIsInitializedWithDurabilityPoints()
        {
            Axe axe = new Axe(10, 10);
            Assert.AreEqual(axe.DurabilityPoints, 10);
        }


        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesn't change after attack.");
        }

        [Test]
        public void AttackMethdShouldThrowExeptionIfDurabilityZero()
        {
            Dummy dummy = new Dummy(100, 100);
            Axe axe = new Axe(10, 10);
            for (int i = 0; i < 10; i++)
            {
                axe.Attack(dummy);
            }

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken.");
        }

        [Test]

        public void AttackTakesPointsFromTarget() 
        {
            Dummy dummy = new Dummy(100, 100);
            Axe axe = new Axe(10, 10);
            axe.Attack(dummy);
            Assert.AreEqual(90, dummy.Health);
        }
    }
}