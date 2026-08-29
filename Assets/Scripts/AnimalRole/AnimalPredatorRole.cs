namespace Game
{
    public class AnimalPredatorRole : AnimalRole
    {
        private PredatorPredatorResolveBehaviour _predatorPredatorResolveBehaviour;

        public void InjectPredatorPredatorResolveBehaviour(PredatorPredatorResolveBehaviour behaviour)
        {
            _predatorPredatorResolveBehaviour = behaviour;
        }

        public override void OnCollision(AnimalRole other)
        {
            other.CollideWithPredator(this);
        }

        public override void CollideWithPredator(AnimalPredatorRole predator)
        {
            // resolve via behaviour
        }

        public override void CollideWithPrey(AnimalPreyRole prey)
        {
            // eat them and display Tasty
        }
    }
}