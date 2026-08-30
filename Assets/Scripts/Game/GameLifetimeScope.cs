using UnityEngine;
using VContainer;
using VContainer.Unity;
using Core;

namespace Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameConfig _gameConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameConfig);
            builder.Register<GameState>(Lifetime.Singleton);
        }
    } 
}
