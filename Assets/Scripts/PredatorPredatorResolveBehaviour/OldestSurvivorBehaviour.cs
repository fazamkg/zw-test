using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public class OldestSurvivorBehaviour : PredatorPredatorResolveBehaviour
    {
        public override AnimalPredatorRole Resolve(AnimalPredatorRole self, AnimalPredatorRole other)
        {
            return null; // todo
        }
    }
}
