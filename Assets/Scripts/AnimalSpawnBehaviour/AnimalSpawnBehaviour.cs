using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public abstract class AnimalSpawnBehaviour
    {
        public abstract void OnInit(Map map, Animal animalPrefab);

        public abstract void Tick(float delta);
    } 
}
