using UnityEngine;
using System.Collections.Generic;

namespace Core
{
    public class ObjectPool<T> : IObjectPool where T : Object, IPoolable
    {
        private T _prefab;
        private Stack<T> _pool = new Stack<T>();

        public ObjectPool(T prefab)
        {
            _prefab = prefab;
        }

        public T Get()
        {
            var popped = _pool.TryPop(out var result);
            if (popped)
            {
                result.OnPopFromPool();
                return result;
            }

            var instance = Object.Instantiate(_prefab);
            instance.OnCreateFromPool(this);
            instance.OnPopFromPool();
            return instance;
        }

        public void ReturnToPool(Object instance)
        {
            var casted = ((T)instance);

            casted.OnReturnToPool();
            _pool.Push(casted);
        }
    } 
}
