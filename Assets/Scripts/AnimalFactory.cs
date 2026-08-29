using UnityEngine;

namespace Game
{
    public class AnimalFactory
    {
        private Map _map;
        private GameConfig _gameConfig;

        public AnimalFactory(Map map, GameConfig gameConfig)
        {
            _map = map;
            _gameConfig = gameConfig;
        }

        public void Tick(float delta)
        {
            var spawnBehaviour = _gameConfig.AnimalSpawnBehaviour;
            spawnBehaviour.Tick(delta);
        }
    } 
}
