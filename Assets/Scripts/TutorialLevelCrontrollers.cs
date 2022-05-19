using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevelCrontrollers : MonoBehaviour
{
    public GameObject popUpMenu;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finished"))
        {
            popUpMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
