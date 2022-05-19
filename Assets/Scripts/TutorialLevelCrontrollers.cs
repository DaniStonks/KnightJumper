using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialLevelCrontrollers : MonoBehaviour
{
    public GameObject pointer;
    public GameObject firstCollider;
    public GameObject secondCollider;
    public GameObject firstDialogBox;
    public GameObject secondDialogBox;
    public GameObject thirdDialogBox;
    public GameObject popUpMenu;
    public Text firstBoxText;
    public Text secondBoxText;
    public Text thirdBoxText;

    public void Start()
    {

        if(LanguagePreference.isEnglish){
            firstBoxText.text = ("To jump hold the space bar for a short time!\n\n"+
                                    "Press space to continue!");
        }
        else{
            firstBoxText.text = ("Para saltar carregue no espaço por pouco tempo!\n\n" +
                                    "Carregue no espaço para continuar!");
        }
        Time.timeScale = 0;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firstDialogBox.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            secondDialogBox.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thirdDialogBox.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finished"))
        {
            popUpMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("SecondBox"))
        {
            if(LanguagePreference.isEnglish){
                secondBoxText.text = ("To charge a jump hold the space bar!\n\n" +
                                        "Press space to continue!");

            }
            else{
                secondBoxText.text = ("Para aumentar o salto fique a precionar o espaço!\n\n" +
                                        "Carregue no espaço para continuar!");
            }
            secondDialogBox.SetActive(true);
            Time.timeScale = 0;
            firstCollider.GetComponent<Collider2D>().enabled = false;
        }
        if (collision.gameObject.CompareTag("ThirdBox"))
        {
            if (LanguagePreference.isEnglish)
            {
                thirdBoxText.text = ("To swap direction double press the space bar!\n\n" + 
                                        "Press space to continue!");

            }
            else
            {
                thirdBoxText.text = ("Para mudar de direção carregue duas vezes no espaço!\n\n" +
                                        "Carregue no espaço para continuar!");
            }
            thirdDialogBox.SetActive(true);
            Time.timeScale = 0;
            pointer.SetActive(true);
            secondCollider.GetComponent<Collider2D>().enabled = false;
        }
    }
}
