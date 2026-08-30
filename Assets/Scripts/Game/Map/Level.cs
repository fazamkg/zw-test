using UnityEngine;
using VContainer.Unity;

namespace Game
{
    public class Level : ITickable
    {
        private AnimalSpawner _animalSpawner;

        public Level(AnimalSpawner animalSpawner)
        {
            _animalSpawner = animalSpawner;
        }

        public void Tick()
        {
            _animalSpawner.Tick(Time.deltaTime);
        }
    } 
}
