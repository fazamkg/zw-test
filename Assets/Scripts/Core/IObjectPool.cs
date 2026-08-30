using UnityEngine;

namespace Core
{
    public interface IObjectPool
    {
        public void ReturnToPool(Object instance);
    }
}
