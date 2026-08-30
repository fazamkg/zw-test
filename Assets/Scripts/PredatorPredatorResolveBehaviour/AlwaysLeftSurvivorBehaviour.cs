using System;

namespace Game
{
    [Serializable]
    public class AlwaysLeftSurvivorBehaviour : PredatorPredatorResolveBehaviour
    {
        public override Animal Resolve(Animal animalA, Animal animalB)
        {
            return animalA;
        }
    }
}
