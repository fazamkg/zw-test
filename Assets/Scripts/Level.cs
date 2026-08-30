using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class Level : ITickable, IStartable
    {
        private GameConfig _gameConfig;
        private AnimalFactory _animalFactory;
        private IObjectResolver _resolver;

        public Level(GameConfig gameConfig, AnimalFactory animalFactory, IObjectResolver resolver)
        {
            _gameConfig = gameConfig;
            _animalFactory = animalFactory;
            _resolver = resolver;
        }

        public void Start()
        {
            var view = Object.Instantiate(_gameConfig.GameView);
            _resolver.InjectGameObject(view.gameObject);
        }

        public void Tick()
        {
            _animalFactory.Tick(Time.deltaTime);
        }
    } 
}
