using System;

namespace Game
{
    [Serializable]
    public abstract class AnimalRoleProvider
    {
        public abstract void Init();

        public abstract AnimalRole Tick(float delta);
    } 
}
