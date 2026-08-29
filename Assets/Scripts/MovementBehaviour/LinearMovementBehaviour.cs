using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class LinearMovementBehaviour : MovementBehaviour
    {
        [SerializeField] private float _speed = 3f;

        public override void Tick(float delta, Vector3 direction, Rigidbody rigidbody)
        {
            rigidbody.linearVelocity = direction.normalized * _speed;
        }
    }
}
