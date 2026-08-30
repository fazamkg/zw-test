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
            builder.RegisterComponent(_map);
            builder.Register<AnimalFactory>(Lifetime.Scoped);
            builder.RegisterEntryPoint<Level>(Lifetime.Scoped);
        }
    } 
}
