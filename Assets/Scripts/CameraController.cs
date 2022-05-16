using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPosition;
    private static readonly float offset = 1.5f;
    private static readonly float offsetSmoothing = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

        /**
         * Offset para a camera de nivel 1
        **/
        if (player.transform.position.y < 0f)
        {
            playerPosition = new Vector3(transform.position.x, player.transform.position.y + offset, transform.position.z);
        }
            else if (player.transform.position.y >= 5f) 
            {
                playerPosition = new Vector3(transform.position.x, player.transform.position.y + (offset* 0.5f), transform.position.z);
            }
        else
        {
            playerPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        
        /**
         * Offset para a camera de nivel 2 
        **/
        /*
        if (player.transform.position.y > 5)
        {
            playerPosition = new Vector3(transform.position.x, player.transform.position.y * offset, transform.position.z);
        }
        else {
            playerPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        */

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
