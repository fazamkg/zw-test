using System;

namespace Game
{
    [Serializable]
    public abstract class PredatorPredatorResolveBehaviour
    {
        public abstract Animal Resolve(Animal animalA, Animal animalB);
    } 
}
