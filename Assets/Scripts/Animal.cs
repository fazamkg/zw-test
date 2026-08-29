using UnityEngine;

namespace Game
{
    public class Animal : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;

        private AnimalConfig _animalConfig;
        private Vector3 _direction;

        public Collider Collider => _collider;
        public AnimalRole AnimalRole { get; private set; }

        public void Init(AnimalConfig animalConfig)
        {
            _animalConfig = animalConfig;
            _animalConfig.AnimalRoleProvider.Init();

            _direction = Helper.GetRandomDirectionHorizontal();
        }

        private void Update()
        {
            AnimalRole = _animalConfig.AnimalRoleProvider.Tick(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _animalConfig.MovementBehaviour.Tick(Time.fixedDeltaTime, _direction, _rigidbody);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var collider = collision.collider;
            if (collider == null) return;

            var otherAnimal = collider.GetComponent<Animal>();
            if (otherAnimal == null)
            {
                for (var i = 0; i < collision.contactCount; i++)
                {
                    var contact = collision.GetContact(i);
                    if (contact.normal == Vector3.up)
                    {
                        continue;
                    }

                    _direction = Vector3.Reflect(_direction, contact.normal);
                    return;
                }
                return;
            }

            var otherRole = otherAnimal.AnimalRole;

            AnimalRole.OnCollision(otherRole);
        }
    } 
}
