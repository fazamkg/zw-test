using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class Animal : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;

        private AnimalConfig _animalConfig;

        public Collider Collider => _collider;

        public void Init(AnimalConfig animalConfig)
        {
            _animalConfig = animalConfig;
        }

        private void Update()
        {
            
        }
    } 
}
