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

        public override AnimalRole Tick(float delta, IAnimal animal, AnimalRoleProviderState state)
        {
            return _animalRole;
        }
    } 
}
