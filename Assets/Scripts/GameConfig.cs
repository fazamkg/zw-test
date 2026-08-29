using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = Consts.GAME_CONFIG_FILE_NAME, menuName = Consts.GAME_CONFIG_MENU_NAME)]
    public class GameConfig : ScriptableObject
    {
        [SerializeReference, SubclassSelector] private AnimalSpawnBehaviour _animalSpawnBehaviour;
        [SerializeField] private Animal _animalPrefab;
        [SerializeField] private GameView _gameView;

        public AnimalSpawnBehaviour AnimalSpawnBehaviour => _animalSpawnBehaviour;
        public Animal AnimalPrefab => _animalPrefab;
        public GameView GameView => _gameView;
    } 
}
