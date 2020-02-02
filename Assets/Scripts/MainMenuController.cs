using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public enum SceneMapping
    {
        MainMenu = 0,
        IntroCutscene = 1,
        MainGame = 2,
    }

    class MainMenuController : MonoBehaviour
    {
        public GameObject CharacterSelectionFlow;

        public void TriggerCharacterSelection(bool show)
        {
            CharacterSelectionFlow.SetActive(show);
            GUI.FocusControl(show ? "Duct" : "StartButton");
        }

        public void LoadMainGame(string ColorChoice = "Duct")
        {
            PlayerPrefs.SetString("Color", ColorChoice);
            SceneManager.LoadScene((int)SceneMapping.IntroCutscene);
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