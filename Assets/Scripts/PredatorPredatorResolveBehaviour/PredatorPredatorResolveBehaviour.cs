using System;

namespace Game
{
    [Serializable]
    public abstract class PredatorPredatorResolveBehaviour
    {
        public abstract AnimalPredatorRole Resolve(AnimalPredatorRole self, AnimalPredatorRole other);
    } 
}
