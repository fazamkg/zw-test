using System;

namespace Game
{
    [Serializable]
    public class AlwaysLeftSurvivorBehaviour : PredatorPredatorResolveBehaviour
    {
        public override AnimalPredatorRole Resolve(AnimalPredatorRole self, AnimalPredatorRole other)
        {
            return self;
        }
    }
}
