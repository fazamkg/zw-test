using System;

namespace Game
{
    [Serializable]
    public abstract class AnimalRole
    {
        public abstract void OnCollision(AnimalRole roleA, AnimalCollisionContext context);

        public abstract void CollideWithPrey(AnimalPreyRole roleB, AnimalCollisionContext context);

        public abstract void CollideWithPredator(AnimalPredatorRole roleB, AnimalCollisionContext context);
    } 
}
