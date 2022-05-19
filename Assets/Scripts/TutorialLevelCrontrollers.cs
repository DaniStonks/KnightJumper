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
        //if(isLanguageEnglish == true){}
        //else if(isLanguageEnglish == false){}
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
            //if(isLanguageEnglish == true){}
            //else if(isLanguageEnglish == false){}
            secondDialogBox.SetActive(true);
            Time.timeScale = 0;
            firstCollider.GetComponent<Collider2D>().enabled = false;
        }
        if (collision.gameObject.CompareTag("ThirdBox"))
        {
            //if(isLanguageEnglish == true){}
            //else if(isLanguageEnglish == false){}
            thirdDialogBox.SetActive(true);
            Time.timeScale = 0;
            pointer.SetActive(true);
            secondCollider.GetComponent<Collider2D>().enabled = false;
        }
    }
}
