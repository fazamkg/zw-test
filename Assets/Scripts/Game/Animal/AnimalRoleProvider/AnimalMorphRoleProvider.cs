using UnityEngine;
using System;

namespace Game
{
    // This is bonus behaviour. Just an example of extensibility

    [Serializable]
    public class AnimalMorphRoleProvider : AnimalRoleProvider
    {
        [SerializeField] private float _morphIntervalSeconds = 3f;
        [SerializeReference, SubclassSelector] private AnimalRole _startFrom = new AnimalPredatorRole();

        private AnimalPreyRole _prey = new();
        private AnimalPredatorRole _predator = new();

        public override void Validate()
        {
            if (_startFrom == null)
            {
                throw new Exception($"Animal Morph Role Provider has null Start From field." +
                    " Please fill in.");
            }

            _startFrom.Validate();
        }

        public override AnimalRole Tick(float delta, IAnimal animal, AnimalRoleProviderState state)
        {
            state.timer += delta;

            if (state.timer > _morphIntervalSeconds)
            {
                state.timer = 0f;

                if (animal.AnimalRole is AnimalPreyRole)
                {
                    return _predator;
                }
                else if (animal.AnimalRole is AnimalPredatorRole)
                {
                    return _prey;
                }
                else
                {
                    return _startFrom;
                }
            }

            return animal.AnimalRole ?? _startFrom;
        }
    }
}
