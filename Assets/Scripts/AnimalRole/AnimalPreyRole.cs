namespace Game
{
    public class AnimalPreyRole : AnimalRole
    {
        public override AnimalCollisionResultPair OnCollision(AnimalRole other)
        {
            return other.CollideWithPrey(this);
        }

        public override AnimalCollisionResultPair CollideWithPredator(AnimalPredatorRole predator)
        {
            var pair = new AnimalCollisionResultPair();

            var self = new AnimalCollisionResult();
            self.IsDead = true;
            pair.Self = self;

            var other = new AnimalCollisionResult();
            other.Ate = true;
            pair.Other = other;

            return pair;
        }

        public override AnimalCollisionResultPair CollideWithPrey(AnimalPreyRole prey)
        {
            var pair = new AnimalCollisionResultPair();

            var self = new AnimalCollisionResult();
            self.ReflectDirection = true;
            pair.Self = self;

            var other = new AnimalCollisionResult();
            other.ReflectDirection = true;
            pair.Other = other;

            return pair;
        }
    }
}
