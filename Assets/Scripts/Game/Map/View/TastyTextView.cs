using UnityEngine;
using Core;
using System;

namespace Game
{
    public class TastyTextView : MonoBehaviour, IPoolable
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _moveSpeed = 2f;
        [SerializeField] private float _fadeSpeed = 1f;

        private IObjectPool _pool;

        public void Validate()
        {
            if (_canvasGroup == null)
            {
                throw new Exception("Canvas group was null on TastyTextView prefab." +
                    " Please fill in the reference");
            }
        }

        private void Update()
        {
            transform.position += _moveSpeed * Time.deltaTime * Vector3.up;
            _canvasGroup.alpha -= _fadeSpeed * Time.deltaTime;

            if (_canvasGroup.alpha <= 0f)
            {
                _pool.ReturnToPool(this);
            }
        }

        public void OnCreateFromPool(IObjectPool pool)
        {
            _pool = pool;
        }

        public void OnPopFromPool()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1f;
        }

        public void OnReturnToPool()
        {
            gameObject.SetActive(false);
        }
    } 
}
