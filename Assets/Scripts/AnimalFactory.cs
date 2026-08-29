namespace Game
{
    public class AnimalFactory
    {
        private Map _map;
        private GameConfig _gameConfig;
        private AnimalSpawnState _spawnInput;

        public AnimalFactory(GameState gameState, Map map, GameConfig gameConfig)
        {
            _map = map;
            _gameConfig = gameConfig;

            _spawnInput = new AnimalSpawnState();
            _spawnInput.gameState = gameState;
            _spawnInput.map = map;
            _spawnInput.animalPrefab = _gameConfig.AnimalPrefab;
            _spawnInput.candidatesBuffer = new();

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
