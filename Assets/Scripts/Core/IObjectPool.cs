using UnityEngine;

namespace Game
{
    public interface IObjectPool
    {
        public void ReturnToPool(Object instance);
    }
}
