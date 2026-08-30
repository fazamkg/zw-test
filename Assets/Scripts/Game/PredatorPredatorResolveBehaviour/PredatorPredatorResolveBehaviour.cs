using System;

namespace Game
{
    [Serializable]
    public abstract class PredatorPredatorResolveBehaviour
    {
        public abstract IAnimal Resolve(IAnimal animalA, IAnimal animalB);
    } 
}
