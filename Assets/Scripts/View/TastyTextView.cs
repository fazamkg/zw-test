using UnityEngine;

namespace Game
{
    public class TastyTextView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _moveSpeed = 2f;
        [SerializeField] private float _fadeSpeed = 1f;

        private void Update()
        {
            transform.position += _moveSpeed * Time.deltaTime * Vector3.up;
            _canvasGroup.alpha -= _fadeSpeed * Time.deltaTime;

            if (_canvasGroup.alpha <= 0f)
            {
                gameObject.SetActive(false);
            }
        }
    } 
}
