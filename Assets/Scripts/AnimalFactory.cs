namespace Game
{
    public class AnimalFactory
    {
        private Map _map;
        private GameConfig _gameConfig;

        public AnimalFactory(GameState gameState, Map map, GameConfig gameConfig)
        {
            _map = map;
            _gameConfig = gameConfig;

            _gameConfig.AnimalSpawnBehaviour.OnInit(gameState, _map, _gameConfig.AnimalPrefab);
        }

        public void Tick(float delta)
        {
            var spawnBehaviour = _gameConfig.AnimalSpawnBehaviour;
            spawnBehaviour.Tick(delta);
        }
    } 
}
