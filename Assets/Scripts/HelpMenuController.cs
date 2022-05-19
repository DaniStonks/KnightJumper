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

    public void SwapLanguageToEnglish() {
        instructionsText.text = ("-> To jump press in the space bar \n" +
                                "-> To empower jump hold the space bar \n" +
                                "-> To swap direction double press in the space bar \n" +
                                "-> To open menu in game press escape");
    }

    public void SwapLanguageToPortuguese()
    {
        instructionsText.text = ("-> Para saltar carregue no espaço \n" +
                                "-> Para aumentar o salto fique a pressionar no espaço \n" +
                                "-> Para mudar de direção carregue duas vezes no espaço \n" +
                                "-> Para abrir o menu dentro do jogo carregue no esc");
    }

    public void PlayTutorialLevel() {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void BackToMainMenu() {
        helpMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
