using UnityEngine;
using System.Collections.Generic;

namespace Game
{
    public class AnimalSpawnState
    {
        public float delta;
        public float timer;
        public float currentIntervalSeconds;
        public Map map;
        public GameState gameState;
        public Animal animalPrefab;
        public List<Vector3> candidatesBuffer;
    }
}
