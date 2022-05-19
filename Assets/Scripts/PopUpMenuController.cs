using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpMenuController : MonoBehaviour
{
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
            Time.timeScale = 0;
        }
    }
    public void ResumeGame()
    {
        popUpMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitToMainMenu()
    {
        popUpMenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        popUpMenu.SetActive(false);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

}
