using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public class AnimalPredatorRoleProvider : AnimalRoleProvider
    {
        [SerializeReference, SubclassSelector]
        private PredatorPredatorResolveBehaviour _predatorPredatorResolveBehaviour;

        private AnimalRole _animalRole;

        public override void Init()
        {
            var predator = new AnimalPredatorRole();
            predator.InjectPredatorPredatorResolveBehaviour(_predatorPredatorResolveBehaviour);
            _animalRole = predator;
        }

        public override AnimalRole Tick(float delta)
        {
            return _animalRole;
        }
    } 
}
