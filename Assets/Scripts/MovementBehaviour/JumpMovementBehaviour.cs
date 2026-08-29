using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class JumpMovementBehaviour : MovementBehaviour
    {
        [SerializeField] private float _jumpIntervalSeconds = 2f;
        [SerializeField] private float _jumpStrength = 2f;
        [SerializeField] private float _jumpAngle = 45f;

        private float _timePassedSeconds;

        public override void Tick(float delta, Vector3 direction, Rigidbody rigidbody)
        {
            direction = direction.normalized;

            _timePassedSeconds += delta;
            if (_timePassedSeconds > _jumpIntervalSeconds)
            {
                _timePassedSeconds = 0f;

                var rotateAxis = Vector3.Cross(direction, Vector3.up);

                rigidbody.linearVelocity = Quaternion.AngleAxis(_jumpAngle, rotateAxis) * direction * _jumpStrength;
            }
        }
    }
}
