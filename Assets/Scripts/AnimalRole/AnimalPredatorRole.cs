using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class AnimalPredatorRole : AnimalRole
    {
        [SerializeReference, SubclassSelector]
        private PredatorPredatorResolveBehaviour _predatorPredatorResolveBehaviour;

        public override AnimalCollisionResultPair OnCollision(AnimalRole other)
        {
            return other.CollideWithPredator(this);
        }

        public override AnimalCollisionResultPair CollideWithPredator(AnimalPredatorRole predator)
        {
            var winner = _predatorPredatorResolveBehaviour.Resolve(this, predator);

            var pair = new AnimalCollisionResultPair();

            var self = new AnimalCollisionResult();
            self.IsDead = winner != this;
            self.Ate = winner == this;
            pair.Self = self;

            var other = new AnimalCollisionResult();
            other.IsDead = winner == this;
            other.Ate = winner != this;
            pair.Other = other;

            return pair;
        }

        public override AnimalCollisionResultPair CollideWithPrey(AnimalPreyRole prey)
        {
            var pair = new AnimalCollisionResultPair();

            var self = new AnimalCollisionResult();
            self.Ate = true;
            pair.Self = self;

            var other = new AnimalCollisionResult();
            other.IsDead = true;
            pair.Other = other;

            return pair;
        }
    }
}