using UnityEngine;
using VContainer;
using VContainer.Unity;
using Core;
using System;

namespace Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameConfig _gameConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            Validate();

            builder.RegisterInstance(_gameConfig);
            builder.Register<GameState>(Lifetime.Singleton);
        }

        public void Validate()
        {
            if (_gameConfig == null)
            {
                throw new Exception($"Game Config was null!" +
                    $" Fill the reference in {Consts.INIT_SCENE_NAME} scene on {gameObject.name}");
            }

            if (_gameConfig.AnimalSpawnBehaviour == null)
            {
                throw new Exception($"Game Config has no {nameof(_gameConfig.AnimalSpawnBehaviour)} set." +
                    $" Please select the behavior");
            }

            _gameConfig.AnimalSpawnBehaviour.Validate();

            if (_gameConfig.AnimalPrefab == null)
            {
                throw new Exception($"Animal Prefab was null!" +
                    $" Fill the reference to animal prefab on Game Config");
            }

            _gameConfig.AnimalPrefab.Validate();

            if (_gameConfig.GameViewPrefab == null)
            {
                throw new Exception($"Game View Prefab was null!" +
                    $" Fill the reference to game view prefab on Game Config");
            }

            _gameConfig.GameViewPrefab.Validate();
        }
    } 
}
