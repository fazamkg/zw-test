using UnityEngine;
using Core;

namespace Game
{
    public delegate void DeathEvent(Animal dead);
    public delegate void AteEvent(Animal eater);

    [SelectionBase]
    public class Animal : MonoBehaviour, IPoolable, IAnimal
    {
        public event DeathEvent OnDeath;
        public event AteEvent OnAte;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;

        private AnimalConfig _animalConfig;
        private Vector3 _direction;
        private float _movementTimer;
        private float _roleTimer;
        private IObjectPool _ownPool;
        private ObjectPool<AnimalVisual> _visualPool;
        private AnimalVisual _visual;

        public Collider Collider => _collider;
        public AnimalRole AnimalRole { get; private set; }
        public bool IsDead { get; private set; }
        public float LifetimeSeconds { get; private set; }

        public void Init(AnimalConfig animalConfig, ObjectPool<AnimalVisual> visualPool)
        {
            _animalConfig = animalConfig;
            _direction = Helper.GetRandomDirectionHorizontal();
            _visualPool = visualPool;

            _visual = _visualPool.Get();
            _visual.transform.SetParent(transform);
            _visual.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }

        private void Update()
        {
            var delta = Time.deltaTime;
            AnimalRole = _animalConfig.AnimalRoleProvider.Tick(delta, this, ref _roleTimer);
            LifetimeSeconds += delta;
        }

        private void FixedUpdate()
        {
            _animalConfig.MovementBehaviour.Tick(Time.fixedDeltaTime, _direction, _rigidbody, ref _movementTimer);
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

            if (GetInstanceID() > otherAnimal.GetInstanceID()) return;

            var context = new AnimalCollisionContext();
            context.animalA = this;
            context.animalB = otherAnimal;
            context.normal = GetCollisionNormal(collision);
            otherRole.OnCollision(AnimalRole, context);
        }

        public void OnCreateFromPool(IObjectPool pool)
        {
            _ownPool = pool;
        }

        public void OnPopFromPool()
        {
            gameObject.SetActive(true);
            _direction = Vector3.zero;
            _movementTimer = 0f;
            _roleTimer = 0f;
            IsDead = false;
            _rigidbody.linearVelocity = Vector3.zero;
            OnDeath = null;
            OnAte = null;
            LifetimeSeconds = 0f;
        }

        public void OnReturnToPool()
        {
            _visual.transform.SetParent(null);
            _visualPool.ReturnToPool(_visual);
            gameObject.SetActive(false);
            IsDead = true;
            OnDeath?.Invoke(this);
        }

        public void Ate()
        {
            OnAte?.Invoke(this);
        }

        public void Die()
        {
            _ownPool.ReturnToPool(this);
        }

        public void ReflectDirection(Vector3 normal)
        {
            if (normal == Vector3.zero) return;

            _direction = Vector3.Reflect(_direction, normal);
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
    }
}
