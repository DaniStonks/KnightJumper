using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private float runSpeed = 350f;
    [SerializeField] private float tapSpeed = 0.3f;
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool changeDirection = false;

    private float buttonTimer = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isFacingRight()){
            horizontalMove = 40f * runSpeed;
        } else {
            horizontalMove = -40f * runSpeed;
        }

        if(Input.GetButtonDown("Jump")){
            if(Time.time - buttonTimer < tapSpeed && controller.isCharacterGrounded()){
                controller.Flip();
                changeDirection = true;
            } else {
                buttonTimer = Time.time;
                jump = true;
            }
        }

        if(controller.isCharacterGrounded()){
            gameObject.GetComponent<Animator>().SetTrigger("TriggerIdle");
        } else {
            gameObject.GetComponent<Animator>().SetTrigger("TriggerJump");
        }
    }

    void FixedUpdate()
    {
        controller.Jump(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
