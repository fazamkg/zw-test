using UnityEngine;
using System;
using Random = UnityEngine.Random;
using Core;

namespace Game
{
    [Serializable]
    public class DefaultAnimalSpawnBehaviour : AnimalSpawnBehaviour
    {
        [SerializeField] private float _minSpawnIntervalSeconds = 1f;
        [SerializeField] private float _maxSpawnIntervalSeconds = 2f;
        [SerializeField] private AnimalConfig[] _animalPool;
        [SerializeField] private float _mapSpacingCheck = 1f;

        public override void Validate()
        {
            if (_animalPool == null)
            {
                throw new Exception($"Animal Pool was null on {nameof(DefaultAnimalSpawnBehaviour)}");
            }

            if (_animalPool.Length == 0)
            {
                throw new Exception($"Animal Poll was empty on {nameof(DefaultAnimalSpawnBehaviour)}");
            }

            if (Mathf.Approximately(0f, _mapSpacingCheck) || _mapSpacingCheck < 0f)
            {
                throw new Exception($"Set map spacing check to more than 0");
            }

            for (var i = 0; i < _animalPool.Length; i++)
            {
                var animalConfig = _animalPool[i];
                animalConfig.Validate();
            }
        }

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

            var animalVisualPrefab = animalConfig.AnimalVisual;
            var animalVisualPool = input.visualPools.GetValueOrCreate(animalVisualPrefab,
                () => new ObjectPool<AnimalVisual>(animalVisualPrefab));

            animalInstance.Init(animalConfig, animalVisualPool);

            var position = Helper.SampleRandomNonOccupiedPositionOnRectGroundNonAlloc(spawnArea,
                animalInstance.Collider, 
                _mapSpacingCheck,
                input.candidatesBuffer);

            animalInstance.transform.position = position;

            input.gameState.OnAnimalSpawn(animalInstance);
        }
    } 
}
