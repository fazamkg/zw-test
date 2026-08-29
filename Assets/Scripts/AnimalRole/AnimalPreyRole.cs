namespace Game
{
    public class AnimalPreyRole : AnimalRole
    {
        public override void OnCollision(AnimalRole other)
        {
            other.CollideWithPrey(this);
        }

        public override void CollideWithPredator(AnimalPredatorRole predator)
        {
            // become dead and disappear from screen
        }

        public override void CollideWithPrey(AnimalPreyRole prey)
        {
            // fly apart by physics
        }
    }
}
