using System;

namespace Game
{
    [Serializable]
    public class AnimalPreyRole : AnimalRole
    {
        public override void Validate()
        {
            // nothing to validate here
        }

        public override void OnCollision(AnimalRole roleA, AnimalCollisionContext context)
        {
            roleA.CollideWithPrey(this, context);
        }

        public override void CollideWithPredator(AnimalPredatorRole roleB, AnimalCollisionContext context)
        {
            context.animalA.Die();
            context.animalB.Ate();
        }

        public override void CollideWithPrey(AnimalPreyRole roleB, AnimalCollisionContext context)
        {
            context.animalA.ReflectDirection(context.normal);
            context.animalB.ReflectDirection(-context.normal);
        }
    }
}
