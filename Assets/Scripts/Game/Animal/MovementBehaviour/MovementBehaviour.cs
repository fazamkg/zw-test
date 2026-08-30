using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public abstract class MovementBehaviour
    {
        public MovementState CreateState() => new MovementState();

        public abstract void Validate();

        public abstract void Tick(float delta, Vector3 direction, Rigidbody rigidbody, MovementState state);
    } 
}
