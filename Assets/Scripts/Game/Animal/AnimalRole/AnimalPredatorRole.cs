using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class AnimalPredatorRole : AnimalRole
    {
        [SerializeReference, SubclassSelector]
        private PredatorPredatorResolveBehaviour _predatorPredatorResolveBehaviour = new RandomSurvivorBehaviour();

        public override void Validate()
        {
            if (_predatorPredatorResolveBehaviour == null)
            {
                throw new Exception($"Predator-predator resolve behaviour was null." +
                    $" Please fill in");
            }
        }

        public void SetPredatorPredatorBehaviour(PredatorPredatorResolveBehaviour behaviour)
        {
            _predatorPredatorResolveBehaviour = behaviour;
        }

        public override void OnCollision(AnimalRole roleA, AnimalCollisionContext context)
        {
            roleA.CollideWithPredator(this, context);
        }

        public override void CollideWithPredator(AnimalPredatorRole roleB, AnimalCollisionContext context)
        {
            var animalA = context.animalA;
            var animalB = context.animalB;

            var winner = _predatorPredatorResolveBehaviour.Resolve(animalA, animalB);

            if (winner == animalA)
            {
                animalA.Ate();
                animalB.Die();
            }
            else
            {
                animalA.Die();
                animalB.Ate();
            }
        }

        public override void CollideWithPrey(AnimalPreyRole roleB, AnimalCollisionContext context)
        {
            context.animalA.Ate();
            context.animalB.Die();
        }
    }
}