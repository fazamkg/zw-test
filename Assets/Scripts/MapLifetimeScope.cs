using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace Game
{
    public class MapLifetimeScope : LifetimeScope
    {
        [SerializeField] private Map _map;

        protected override void Configure(IContainerBuilder builder)
        {
            var gameConfig = Parent.Container.Resolve<GameConfig>();

            builder.RegisterComponent(_map);
            builder.Register<AnimalSpawner>(Lifetime.Scoped);
            builder.RegisterComponentInNewPrefab(gameConfig.GameViewPrefab, Lifetime.Scoped);
            builder.RegisterEntryPoint<Level>(Lifetime.Scoped);
        }
    } 
}
