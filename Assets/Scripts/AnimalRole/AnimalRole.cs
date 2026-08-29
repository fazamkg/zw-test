namespace Game
{
    public abstract class AnimalRole
    {
        public abstract void OnCollision(AnimalRole other);

        public abstract void CollideWithPrey(AnimalPreyRole prey);

        public abstract void CollideWithPredator(AnimalPredatorRole predator);
    } 
}
