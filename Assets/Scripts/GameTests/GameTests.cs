using NUnit.Framework;
using UnityEngine;
using Game;

namespace GameTests
{
    public class GameTests
    {
        [Test]
        public void AnimalRole_Collision_PreyPrey()
        {
            var animalA = new AnimalMock();
            var animalB = new AnimalMock(Vector3.back);

            var roleA = new AnimalPreyRole();
            var roleB = new AnimalPreyRole();

            Assert.IsFalse(animalA.IsDead);
            Assert.IsFalse(animalB.IsDead);

            Assert.IsFalse(animalA.DidEat);
            Assert.IsFalse(animalB.DidEat);

            Assert.AreEqual(Vector3.forward, animalA.Direction);
            Assert.AreEqual(Vector3.back, animalB.Direction);

            var context = new AnimalCollisionContext();
            context.animalA = animalA;
            context.animalB = animalB;
            context.normal = Vector3.back;

            roleB.OnCollision(roleA, context);

            Assert.IsFalse(animalA.IsDead);
            Assert.IsFalse(animalB.IsDead);

            Assert.IsFalse(animalA.DidEat);
            Assert.IsFalse(animalB.DidEat);

            Assert.AreEqual(Vector3.back, animalA.Direction);
            Assert.AreEqual(Vector3.forward, animalB.Direction);
        }

        [Test]
        public void AnimalRole_Collision_PreyPredator()
        {
            var animalA = new AnimalMock();
            var animalB = new AnimalMock(Vector3.back);

            var roleA = new AnimalPreyRole();
            var roleB = new AnimalPredatorRole();

            Assert.IsFalse(animalA.IsDead);
            Assert.IsFalse(animalB.IsDead);

            Assert.IsFalse(animalA.DidEat);
            Assert.IsFalse(animalB.DidEat);

            Assert.AreEqual(Vector3.forward, animalA.Direction);
            Assert.AreEqual(Vector3.back, animalB.Direction);

            var context = new AnimalCollisionContext();
            context.animalA = animalA;
            context.animalB = animalB;
            context.normal = Vector3.back;

            roleB.OnCollision(roleA, context);

            Assert.IsTrue(animalA.IsDead);
            Assert.IsFalse(animalB.IsDead);

            Assert.IsFalse(animalA.DidEat);
            Assert.IsTrue(animalB.DidEat);

            Assert.AreEqual(Vector3.forward, animalA.Direction);
            Assert.AreEqual(Vector3.back, animalB.Direction);
        }

        [Test]
        public void AnimalRole_Collision_PredatorPredator_AlwaysLeft()
        {
            var animalA = new AnimalMock();
            var animalB = new AnimalMock(Vector3.back);

            var roleA = new AnimalPredatorRole();
            var roleB = new AnimalPredatorRole();
            roleA.SetPredatorPredatorBehaviour(new AlwaysLeftSurvivorBehaviour());
            roleB.SetPredatorPredatorBehaviour(new AlwaysLeftSurvivorBehaviour());

            Assert.IsFalse(animalA.IsDead);
            Assert.IsFalse(animalB.IsDead);

            Assert.IsFalse(animalA.DidEat);
            Assert.IsFalse(animalB.DidEat);

            Assert.AreEqual(Vector3.forward, animalA.Direction);
            Assert.AreEqual(Vector3.back, animalB.Direction);

            var context = new AnimalCollisionContext();
            context.animalA = animalA;
            context.animalB = animalB;
            context.normal = Vector3.back;

            roleB.OnCollision(roleA, context);

            Assert.IsFalse(animalA.IsDead);
            Assert.IsTrue(animalB.IsDead);

            Assert.IsTrue(animalA.DidEat);
            Assert.IsFalse(animalB.DidEat);

            Assert.AreEqual(Vector3.forward, animalA.Direction);
            Assert.AreEqual(Vector3.back, animalB.Direction);
        }
    } 
}
