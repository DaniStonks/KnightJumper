using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject helpMenu;

    public void StartGame() {
        SceneManager.LoadScene(0);
    }

    public void GoToHelpMenu() {
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
    }

    public void ExitGame() {
        Application.Quit(0);
    }
}
