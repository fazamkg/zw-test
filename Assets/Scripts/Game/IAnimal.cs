using UnityEngine;

namespace Game
{
    public interface IAnimal
    {
        float LifetimeSeconds { get; }

        public void Die();

        public void Ate();

        public void ReflectDirection(Vector3 normal);
    } 
}
