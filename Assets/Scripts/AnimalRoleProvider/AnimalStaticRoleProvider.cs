using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public class AnimalStaticRoleProvider : AnimalRoleProvider
    {
        [SerializeReference, SubclassSelector] private AnimalRole _animalRole;

        public override AnimalRole Tick(float delta)
        {
            return _animalRole;
        }
    } 
}
