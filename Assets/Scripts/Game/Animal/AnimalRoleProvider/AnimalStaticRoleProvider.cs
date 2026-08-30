using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public class AnimalStaticRoleProvider : AnimalRoleProvider
    {
        [SerializeReference, SubclassSelector] private AnimalRole _animalRole = new AnimalPreyRole();

        public override void Validate()
        {
            if (_animalRole == null)
            {
                throw new Exception($"Animal Role was null on AnimalStaticRoleProvider." +
                    $" Please fill in");
            }
        }

        public override AnimalRole Tick(float delta, Animal animal, ref float timer)
        {
            return _animalRole;
        }
    } 
}
