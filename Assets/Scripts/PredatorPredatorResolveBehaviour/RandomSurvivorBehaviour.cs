using System;
using Random = UnityEngine.Random;

namespace Game
{
    [Serializable]
    public class RandomSurvivorBehaviour : PredatorPredatorResolveBehaviour
    {
        public override Animal Resolve(Animal animalA, Animal animalB)
        {
            return Random.Range(0f, 1f) < 0.5f ? animalA : animalB;
        }
    }
}
