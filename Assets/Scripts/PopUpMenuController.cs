using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpMenuController : MonoBehaviour
{
    public AudioSource clickButton;
    public GameObject popUpMenu;

    // Start is called before the first frame update
    void Start()
    {
        popUpMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            popUpMenu.SetActive(true);
            AudioListener.pause = true;
            Time.timeScale = 0;
        }
    }
    public void ResumeGame()
    {
        popUpMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        clickButton.Play();
    }

    public void ExitToMainMenu()
    {
        popUpMenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
        AudioListener.pause = false;
        Time.timeScale = 1;
        clickButton.Play();
    }

    public void RestartGame()
    {
        clickButton.Play();
        popUpMenu.SetActive(false);
        AudioListener.pause = false;
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

}
