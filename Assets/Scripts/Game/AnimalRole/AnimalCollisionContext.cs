using UnityEngine;

namespace Game
{
    public struct AnimalCollisionContext
    {
        public IAnimal animalA;
        public IAnimal animalB;
        public Vector3 normal;
    }
}
