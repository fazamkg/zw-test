using System;

namespace Game
{
    [Serializable]
    public class AnimalPreyRoleProvider : AnimalRoleProvider
    {
        private AnimalRole _animalRole;

        public override void Init()
        {
            _animalRole = new AnimalPreyRole();
        }

        public override AnimalRole Tick(float delta)
        {
            return _animalRole;
        }
    }
}
