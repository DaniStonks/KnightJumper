using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelpMenuController : MonoBehaviour
{
    public GameObject helpMenu;
    public GameObject mainMenu;
    public Text instructionsText;
    private bool isLanguageEnglish;

    private void Start()
    {
        SetIsLanguageEnglish(true);
    }

    public void SwapLanguageToEnglish() {
        instructionsText.text = ("-> To jump press in the space bar \n" +
                                "-> To empower jump hold the space bar \n" +
                                "-> To swap direction double press in the space bar \n" +
                                "-> To open menu in game press escape");
        SetIsLanguageEnglish(true);
    }

    public void SwapLanguageToPortuguese()
    {
        instructionsText.text = ("-> Para saltar carregue no espa�o \n" +
                                "-> Para aumentar o salto fique a pressionar no espa�o \n" +
                                "-> Para mudar de dire��o carregue duas vezes no espa�o \n" +
                                "-> Para abrir o menu dentro do jogo carregue no esc");
        SetIsLanguageEnglish(false);
    }

    public void PlayTutorialLevel() {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void BackToMainMenu() {
        helpMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    private bool GetIsLanguageEnglish() {
        return isLanguageEnglish;
    }

    private void SetIsLanguageEnglish(bool value) {
        isLanguageEnglish = value;
    }
}
