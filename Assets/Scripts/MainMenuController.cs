using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public enum SceneMapping
    {
        MainMenu = 0,
        MainGame = 1,
        Cutscene = 2
    }

    class MainMenuController : MonoBehaviour
    {
        public void LoadMainGame()
        {
            SceneManager.LoadScene((int)SceneMapping.MainGame);
        }

        public void ExitApplication()
        {
            Application.Quit();
        }

        public void LoadScene(SceneMapping scene)
        {
            SceneManager.LoadScene((int)scene);
        }

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}