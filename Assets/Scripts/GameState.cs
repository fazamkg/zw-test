using System;
using System.Collections.Generic;

namespace Game
{
    public class GameState
    {
        public event Action OnDeadAmountUpdated;

        public Dictionary<Type, int> DeadAmount { get; private set; } = new();

        public void OnAnimalSpawn(Animal animal)
        {
            animal.OnDeath += Animal_OnDeath;
        }

        private void Animal_OnDeath(Animal animal)
        {
            DeadAmount.Bump(animal.AnimalRole.GetType());

            OnDeadAmountUpdated?.Invoke();
        }
    }
}
