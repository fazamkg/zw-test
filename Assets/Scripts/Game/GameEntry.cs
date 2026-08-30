using UnityEngine;
using UnityEngine.SceneManagement;
using Core;

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
