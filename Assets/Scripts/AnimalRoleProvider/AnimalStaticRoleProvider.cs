using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public class AnimalStaticRoleProvider : AnimalRoleProvider
    {
        [SerializeReference, SubclassSelector] private AnimalRole _animalRole;

        public override AnimalRole Tick(float delta, Animal animal, ref float timer)
        {
            return _animalRole;
        }
    } 
}
