using System;
using Random = UnityEngine.Random;

namespace Game
{
    [Serializable]
    public class RandomSurvivorBehaviour : PredatorPredatorResolveBehaviour
    {
        public override AnimalPredatorRole Resolve(AnimalPredatorRole self, AnimalPredatorRole other)
        {
            return Random.Range(0f, 1f) < 0.5f ? self : other;
        }
    }
}
