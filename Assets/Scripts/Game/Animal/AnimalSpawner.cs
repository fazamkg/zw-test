using Core;

namespace Game
{
    public class AnimalSpawner
    {
        private GameConfig _gameConfig;
        private AnimalSpawnState _spawnInput;

        public AnimalSpawner(GameState gameState, Map map, GameConfig gameConfig)
        {
            _gameConfig = gameConfig;

            _spawnInput = new AnimalSpawnState();
            _spawnInput.gameState = gameState;
            _spawnInput.map = map;
            _spawnInput.candidatesBuffer = new();
            _spawnInput.animalPool = new ObjectPool<Animal>(_gameConfig.AnimalPrefab);

            _gameConfig.AnimalSpawnBehaviour.OnInit(_spawnInput);
        }

        public void Tick(float delta)
        {
            var spawnBehaviour = _gameConfig.AnimalSpawnBehaviour;

            _spawnInput.delta = delta;
            spawnBehaviour.Tick(_spawnInput);
        }
    } 
}
