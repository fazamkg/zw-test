using System;

namespace Game
{
    [Serializable]
    public abstract class AnimalRoleProvider
    {
        public AnimalRoleProviderState CreateState() => new AnimalRoleProviderState();

        public abstract AnimalRole Tick(float delta, IAnimal animal, AnimalRoleProviderState state);

        public abstract void Validate();
    } 
}
