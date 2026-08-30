using System;
using Random = UnityEngine.Random;

namespace Game
{
    [Serializable]
    public class RandomSurvivorBehaviour : PredatorPredatorResolveBehaviour
    {
        public override IAnimal Resolve(IAnimal animalA, IAnimal animalB)
        {
            return Random.Range(0f, 1f) < 0.5f ? animalA : animalB;
        }
    }
}
