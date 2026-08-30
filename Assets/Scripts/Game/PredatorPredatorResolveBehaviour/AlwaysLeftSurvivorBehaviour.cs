using System;

namespace Game
{
    [Serializable]
    public class AlwaysLeftSurvivorBehaviour : PredatorPredatorResolveBehaviour
    {
        public override IAnimal Resolve(IAnimal animalA, IAnimal animalB)
        {
            return animalA;
        }
    }
}
