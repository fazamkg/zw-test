using System;

namespace Game
{
    [Serializable]
    public class OldestSurvivorBehaviour : PredatorPredatorResolveBehaviour
    {
        public override Animal Resolve(Animal animalA, Animal animalB)
        {
            return animalA.LifetimeSeconds > animalB.LifetimeSeconds ? animalA : animalB;
        }
    }
}
