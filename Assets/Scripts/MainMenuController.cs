using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public AudioSource clickButton;
    public GameObject mainMenu;
    public GameObject helpMenu;

    public void StartGame() {
        SceneManager.LoadScene("Game");
        clickButton.Play();
    }

    public void GoToHelpMenu() {
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
        clickButton.Play();
    }

    public void ExitGame() {
        Application.Quit(0);
        clickButton.Play();
    }
}
