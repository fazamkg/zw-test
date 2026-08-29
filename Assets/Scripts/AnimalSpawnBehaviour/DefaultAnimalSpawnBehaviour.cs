using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
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

        private float _currentTimeSeconds;
        private float _currentIntervalSeconds;
        private GameState _gameState;
        private Map _map;
        private Animal _animalPrefab;
        private List<Vector3> _candidatesBuffer = new List<Vector3>();

        public override void OnInit(GameState gameState, Map map, Animal animalPrefab)
        {
            _gameState = gameState;
            _map = map;
            _animalPrefab = animalPrefab;
            SetNewInterval();
        }

        public override void Tick(float delta)
        {
            _currentTimeSeconds += delta;

            if (_currentTimeSeconds > _currentIntervalSeconds)
            {
                _currentTimeSeconds = 0f;

                SetNewInterval();

                Spawn();
            }
        }

        private void SetNewInterval()
        {
            _currentIntervalSeconds = Random.Range(_minSpawnIntervalSeconds, _maxSpawnIntervalSeconds);
        }

        private void Spawn()
        {
            var spawnArea = _map.SpawnArea;

            var animalConfig = _animalPool.GetRandom();

            // todo: object pool
            var animalInstance = Object.Instantiate(_animalPrefab);
            animalInstance.Init(animalConfig);

            var position = Helper.SampleRandomNonOccupiedPositionOnRectGroundNonAlloc(spawnArea,
                animalInstance.Collider,
                _mapSpacingCheck,
                _candidatesBuffer);

            animalInstance.transform.position = position;

            _gameState.OnAnimalSpawn(animalInstance);
        }
    } 
}
