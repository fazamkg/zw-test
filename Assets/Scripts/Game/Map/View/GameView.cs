using UnityEngine;
using TMPro;
using VContainer;
using Core;
using System;

namespace Game
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _deadPreyAmountText;
        [SerializeField] private TMP_Text _deadPredatorAmountText;
        [SerializeField] private TastyTextView _tastyTextViewPrefab;
        [SerializeField] private Vector3 _tastyTextOffset = new(0f, -100f, 0f);

        private GameState _gameState;
        private Camera _camera;
        private ObjectPool<TastyTextView> _tastyTextPool;

        public void Validate()
        {
            if (_deadPreyAmountText == null)
            {
                throw new Exception("Dead prey amount text was null on GameView prefab." +
                    " Please fill in the reference");
            }

            if (_deadPredatorAmountText == null)
            {
                throw new Exception("Dead predator amount text was null on GameView prefab." +
                    " Please fill in the reference");
            }

            if (_tastyTextViewPrefab == null)
            {
                throw new Exception("Tasty text view prefab was null on GameView prefab." +
                    " Please fill in the reference");
            }

            _tastyTextViewPrefab.Validate();
        }

        [Inject]
        public void Init(GameState gameState, Map map)
        {
            _camera = map.Camera;
            _gameState = gameState;
            _tastyTextPool = new ObjectPool<TastyTextView>(_tastyTextViewPrefab);

            gameState.OnDeadAmountUpdated += UpdateView;

            gameState.OnSomeoneAte += GameState_OnSomeoneAte;

            UpdateView();
        }

        private void GameState_OnSomeoneAte(Animal eater)
        {
            var instance = _tastyTextPool.Get();
            instance.transform.SetParent(transform);
            instance.transform.position = _camera.WorldToScreenPoint(eater.transform.position) + _tastyTextOffset;
        }

        private void UpdateView()
        {
            // Technically not going to scale well. But I prefer
            // simple solution for UI since UI in games can end up
            // with unique looks per counter. So for unique looks per counter manual
            // reference wiring like I do here feels better

            _deadPredatorAmountText.text = _gameState.DeadAmount
                .GetValueOrDefault(typeof(AnimalPredatorRole), 0).ToString();
            _deadPreyAmountText.text = _gameState.DeadAmount
                .GetValueOrDefault(typeof(AnimalPreyRole), 0).ToString();
        }
    } 
}
