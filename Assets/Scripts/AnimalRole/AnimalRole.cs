using System;

namespace Game
{
    [Serializable]
    public abstract class AnimalRole
    {
        public abstract AnimalCollisionResultPair OnCollision(AnimalRole other);

        public abstract AnimalCollisionResultPair CollideWithPrey(AnimalPreyRole prey);

        public abstract AnimalCollisionResultPair CollideWithPredator(AnimalPredatorRole predator);
    } 
}
