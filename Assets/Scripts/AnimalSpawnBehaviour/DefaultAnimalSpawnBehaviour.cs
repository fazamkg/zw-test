using UnityEngine;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

namespace Game
{
    [Serializable]
    public class DefaultAnimalSpawnBehaviour : AnimalSpawnBehaviour
    {
        [SerializeField] private float _minSpawnIntervalSeconds = 1f;
        [SerializeField] private float _maxSpawnIntervalSeconds = 2f;
        [SerializeField] private AnimalConfig[] _animalPool;
        [SerializeField] private float _mapSpacingCheck = 1f;

        public override void OnInit(AnimalSpawnState input)
        {
            SetNewInterval(input);
        }

        public override void Tick(AnimalSpawnState input)
        {
            input.timer += input.delta;

            if (input.timer > input.currentIntervalSeconds)
            {
                input.timer = 0f;

                SetNewInterval(input);

                Spawn(input);
            }
        }

        private void SetNewInterval(AnimalSpawnState input)
        {
            input.currentIntervalSeconds = Random.Range(_minSpawnIntervalSeconds, _maxSpawnIntervalSeconds);
        }

        private void Spawn(AnimalSpawnState input)
        {
            var spawnArea = input.map.SpawnArea;

            var animalConfig = _animalPool.GetRandom();

            var animalInstance = input.animalPool.Get();
            animalInstance.Init(animalConfig);

            var position = Helper.SampleRandomNonOccupiedPositionOnRectGroundNonAlloc(spawnArea,
                animalInstance.Collider, 
                _mapSpacingCheck,
                input.candidatesBuffer);

            animalInstance.transform.position = position;

            input.gameState.OnAnimalSpawn(animalInstance);
        }
    } 
}
