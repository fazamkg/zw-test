using System;

namespace Game
{
    [Serializable]
    public abstract class AnimalSpawnBehaviour
    {
        public abstract void OnInit(AnimalSpawnState input);

        public abstract void Tick(AnimalSpawnState input);

        public abstract void Validate();
    } 
}
