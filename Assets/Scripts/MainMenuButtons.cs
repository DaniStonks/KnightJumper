using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject helpMenu;

    public void StartGame() {
        SceneManager.LoadScene("sampleScene");
    }

    public void GoToHelpMenu() {
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
    }

    public void ExitGame() {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
