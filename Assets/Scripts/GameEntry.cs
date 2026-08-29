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

            _animalFactory = new AnimalFactory(map, _gameConfig);
        }

        private void Update()
        {
            _animalFactory?.Tick(Time.deltaTime);
        }
    } 
}
