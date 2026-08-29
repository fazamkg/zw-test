using UnityEngine;
using System;

namespace Game
{
    public class Animal : MonoBehaviour
    {
        public event Action<Animal> OnDeath;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;

        private AnimalConfig _animalConfig;
        private Vector3 _direction;

        public Collider Collider => _collider;
        public AnimalRole AnimalRole { get; private set; }
        public bool IsDead { get; private set; }

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
            if (IsDead) return;

            var collider = collision.collider;
            if (collider == null) return;

            var otherAnimal = collider.GetComponent<Animal>();
            if (otherAnimal == null)
            {
                var normal = GetCollisionNormal(collision);
                ReflectDirection(normal);
                return;
            }

            var otherRole = otherAnimal.AnimalRole;
            if (otherRole == null) return;
            if (AnimalRole == null) return;

            var result = otherRole.OnCollision(AnimalRole);

            if (result.Self.ReflectDirection)
            {
                var normal = GetCollisionNormal(collision);
                ReflectDirection(normal);
            }

            if (result.Other.ReflectDirection)
            {
                var normal = GetCollisionNormal(collision);
                otherAnimal.ReflectDirection(-normal);
            }

            if (result.Self.IsDead)
            {
                Die();
            }

            if (result.Other.IsDead)
            {
                otherAnimal.Die();
            }
        }

        private void Die()
        {
            gameObject.SetActive(false);
            IsDead = true;
            OnDeath?.Invoke(this);
        }

        private Vector3 GetCollisionNormal(Collision collision)
        {
            for (var i = 0; i < collision.contactCount; i++)
            {
                var contact = collision.GetContact(i);
                if (contact.normal == Vector3.up)
                {
                    continue;
                }
                return contact.normal;
            }

            return Vector3.zero;
        }

        private void ReflectDirection(Vector3 normal)
        {
            if (normal == Vector3.zero) return;

            _direction = Vector3.Reflect(_direction, normal);
        }
    }
}
