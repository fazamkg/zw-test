using System;

namespace Game
{
    [Serializable]
    public abstract class AnimalRoleProvider
    {
        public abstract AnimalRole Tick(float delta, IAnimal animal, ref float timer);

        public abstract void Validate();
    } 
}
