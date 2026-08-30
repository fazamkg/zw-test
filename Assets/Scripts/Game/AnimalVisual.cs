using UnityEngine;
using Core;

namespace Game
{
    public class AnimalVisual : MonoBehaviour, IPoolable
    {
        public void OnCreateFromPool(IObjectPool pool)
        {
        }

        public void OnPopFromPool()
        {
            gameObject.SetActive(true);
        }

        public void OnReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}
