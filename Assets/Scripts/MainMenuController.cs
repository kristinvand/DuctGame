using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public enum SceneMapping
    {
        MainMenu = 0,
        MainGame = 1
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
    }
}