using System;

namespace Game
{
    [Serializable]
    public class OldestSurvivorBehaviour : PredatorPredatorResolveBehaviour
    {
        public override IAnimal Resolve(IAnimal animalA, IAnimal animalB)
        {
            return animalA.LifetimeSeconds > animalB.LifetimeSeconds ? animalA : animalB;
        }
    }
}
