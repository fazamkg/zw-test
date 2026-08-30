using System;

namespace Game
{
    [Serializable]
    public abstract class AnimalRoleProvider
    {
        public abstract AnimalRole Tick(float delta, Animal animal, ref float timer);

        public abstract void Validate();
    } 
}
