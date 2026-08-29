using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class LinearMovementBehaviour : MovementBehaviour
    {
        [SerializeField] private float _speed = 3f;

        public override void Tick(float delta, Vector3 direction, Rigidbody rigidbody, ref float timer)
        {
            var originalVelocity = rigidbody.linearVelocity;

            var newVelocity = direction.normalized * _speed;
            newVelocity.y = originalVelocity.y;

            rigidbody.linearVelocity = newVelocity;
        }
    }
}
