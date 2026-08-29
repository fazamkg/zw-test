using UnityEngine;
using TMPro;

namespace Game
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _deadPreyAmountText;
        [SerializeField] private TMP_Text _deadPredatorAmountText;

        private GameState _gameState;

        public void Init(GameState gameState)
        {
            _gameState = gameState;

            gameState.OnDeadAmountUpdated += UpdateView;

            UpdateView();
        }

        private void UpdateView()
        {
            _deadPredatorAmountText.text = _gameState.DeadAmount
                .GetValueOrDefault(typeof(AnimalPreyRole), 0).ToString();
            _deadPreyAmountText.text = _gameState.DeadAmount
                .GetValueOrDefault(typeof(AnimalPredatorRole), 0).ToString();
        }
    } 
}
