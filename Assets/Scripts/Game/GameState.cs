using System;
using System.Collections.Generic;
using Core;

namespace Game
{
    public class GameState
    {
        public event Action OnDeadAmountUpdated;
        public event AteEvent OnSomeoneAte;

        public Dictionary<Type, int> DeadAmount { get; private set; } = new();

        public void OnAnimalSpawn(Animal animal)
        {
            animal.OnDeath += Animal_OnDeath;
            animal.OnAte += Animal_OnAte;
        }

        private void Animal_OnAte(Animal eater)
        {
            OnSomeoneAte?.Invoke(eater);
        }

        private void Animal_OnDeath(Animal dead)
        {
            DeadAmount.Bump(dead.AnimalRole.GetType());

            OnDeadAmountUpdated?.Invoke();
        }
    }
}
