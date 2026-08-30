using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameEntry : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene(Consts.MAIN_SCENE_NAME);
        }
    } 
}
