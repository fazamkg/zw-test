using UnityEngine;
using Game;

namespace GameTests
{
    public class AnimalMock : IAnimal
    {
        public bool DidEat { get; private set; }

        public bool IsDead { get; private set; }

        public Vector3 Direction { get; private set; }

        public float LifetimeSeconds { get; private set; }

        public AnimalRole AnimalRole { get; private set; }

        public AnimalMock()
        {
            DidEat = false;
            IsDead = false;
            Direction = Vector3.forward;
            LifetimeSeconds = 0f;
        }

        public AnimalMock(bool didEat, bool isDead, Vector3 direction, float lifetimeSeconds)
        {
            DidEat = didEat;
            IsDead = isDead;
            Direction = direction;
            LifetimeSeconds = lifetimeSeconds;
        }

        public AnimalMock(Vector3 direction)
        {
            DidEat = false;
            IsDead = false;
            Direction = direction;
            LifetimeSeconds = 0f;
        }

        public void Ate()
        {
            DidEat = true;
        }

        public void Die()
        {
            IsDead = true;
        }

        public void ReflectDirection(Vector3 normal)
        {
            if (normal == Vector3.zero) return;

            Direction = Vector3.Reflect(Direction, normal);
        }

        public void IncreaseLifetime(float seconds)
        {
            LifetimeSeconds += seconds;
        }
    }
}
