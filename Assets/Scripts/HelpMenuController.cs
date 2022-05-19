using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelpMenuController : MonoBehaviour
{
    public AudioSource clickButton;
    public GameObject helpMenu;
    public GameObject mainMenu;
    public Text instructionsText;
    

    private void Start()
    {
        LanguagePreference.isEnglish = true;
    }

    public void SwapLanguageToEnglish() {
        instructionsText.text = ("-> To jump press in the space bar \n" +
                                "-> To empower jump hold the space bar \n" +
                                "-> To swap direction double press in the space bar \n" +
                                "-> To open menu in game press escape");
        LanguagePreference.isEnglish = true;
        clickButton.Play();
    }

    public void SwapLanguageToPortuguese()
    {
        instructionsText.text = ("-> Para saltar carregue no espaço \n" +
                                "-> Para aumentar o salto fique a pressionar no espaço \n" +
                                "-> Para mudar de direção carregue duas vezes no espaço \n" +
                                "-> Para abrir o menu dentro do jogo carregue no esc");
        LanguagePreference.isEnglish = false;
        clickButton.Play();
    }

    public void PlayTutorialLevel() {
        SceneManager.LoadScene("TutorialLevel");
        clickButton.Play();
    }

    public void BackToMainMenu() {
        helpMenu.SetActive(false);
        mainMenu.SetActive(true);
        clickButton.Play();
    }
}
