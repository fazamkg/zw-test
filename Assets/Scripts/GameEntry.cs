using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameEntry : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;

        private AnimalFactory _animalFactory;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            SceneManager.LoadScene(Consts.MAIN_SCENE_NAME);
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            var map = FindFirstObjectByType<Map>(FindObjectsInactive.Exclude);

            var gameState = new GameState();

            _animalFactory = new AnimalFactory(gameState, map, _gameConfig);

            var gameView = Instantiate(_gameConfig.GameView);
            gameView.Init(gameState);
        }

        private void Update()
        {
            _animalFactory?.Tick(Time.deltaTime);
        }
    } 
}
