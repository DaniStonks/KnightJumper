using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGameController : MonoBehaviour
{
    [SerializeField]private PlayerMovement jumpStats;
    [SerializeField]private TimeController timeStats;
    [SerializeField]private GameObject finishMenu;
    [SerializeField]private Text timeTaken;
    [SerializeField]private Text jumps;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.CompareTag("Player")){
            timeTaken.text = timeStats.getTimeElapsed().ToString(@"hh\:mm\:ss");
            jumps.text = jumpStats.getJumps().ToString();
            finishMenu.SetActive(true);
            Time.timeScale = 0;
		}
	}
}
