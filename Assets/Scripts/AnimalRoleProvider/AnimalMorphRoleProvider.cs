using UnityEngine;
using System;

namespace Game
{
    // This is bonus behaviour. Just an example of extensibility

    [Serializable]
    public class AnimalMorphRoleProvider : AnimalRoleProvider
    {
        [SerializeField] private float _morphIntervalSeconds = 3f;
        [SerializeReference, SubclassSelector] private AnimalRole _startFrom;

        private AnimalPreyRole _prey = new();
        private AnimalPredatorRole _predator = new();

        public override AnimalRole Tick(float delta, Animal animal, ref float timer)
        {
            timer += delta;

            if (timer > _morphIntervalSeconds)
            {
                timer = 0f;

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
