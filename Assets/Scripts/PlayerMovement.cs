using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float tapSpeed = 0.3f;
    [SerializeField] private float maxJumpForce = 650f;	// Amount of force added when the player jumps.
    [SerializeField] private float horizontalJumpForce = 400f;
    [SerializeField] private float maxChargeTime = 1.5f;
    [SerializeField] private float minChargeTime = 0.15f;
    //linear function to calculate jump power y=mx+b
    //jumpFunctionSlope is m
    private float jumpFunctionSlope = 348.148148148f;
    private float jumpFunctionConstant = 127.7777777f;
	private Rigidbody2D rb2D;
    private bool isGrounded; //Whether or not the character is touching the ground
	private bool isHit;
	private bool facingRight = true;  // For determining which way the player is currently facing.
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool maxCharge = false;
    [SerializeField] private float clicked = 0;
    [SerializeField]private float buttonTimer = 0f;
    [SerializeField]private float tapTimer = 0f;
    [SerializeField]private float jumpForce;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //jumpFunctionSlope = maxJumpForce/maxChargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(facingRight){
            horizontalMove = 40f * horizontalJumpForce;
        } else {
            horizontalMove = -40f * horizontalJumpForce;
        }

        if(Input.GetButton("Jump") && !maxCharge && isGrounded){

            if(buttonTimer >= minChargeTime){
                gameObject.GetComponent<Animator>().SetTrigger("TriggerCharge");
                jumpForce = (jumpFunctionSlope * buttonTimer) + jumpFunctionConstant;
            }
            if(buttonTimer >= maxChargeTime){
                maxCharge = true;
            }

            buttonTimer += Time.deltaTime;
        }
        if(Input.GetButtonUp("Jump") || maxCharge){
            if(jumpForce > 0){
                jump = true;
            }
            buttonTimer = 0f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded){
            clicked += 1;
            if (clicked == 1) tapTimer = Time.time;
        }
        if (clicked > 1 && Time.time - tapTimer < tapSpeed)
        {
            Flip();
            clicked = 0;
            tapTimer = 0;
        } else if (clicked > 2 || Time.time - tapTimer > 1){
            clicked = 0;
        }

        if(isGrounded){
            gameObject.GetComponent<Animator>().SetTrigger("TriggerIdle");
        } else if(isHit) {
            gameObject.GetComponent<Animator>().SetTrigger("TriggerHit");
        } else {
            gameObject.GetComponent<Animator>().SetTrigger("TriggerJump");
        }
    }

    void FixedUpdate()
    {
        Jump(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        maxCharge = false;
        jumpForce = 0f;
    }

	public void Jump(float horizontalForce, bool crouch, bool jump)
	{
		if (isGrounded && jump)
		{
			// Add a vertical force to the player.
			isGrounded = false;
			rb2D.AddForce(new Vector2(horizontalForce, jumpForce));
		}
	}

	public void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.CompareTag("Ground")){
            rb2D.velocity = Vector3.zero;
            rb2D.angularVelocity = 0f; 
			isGrounded = true;
            isHit = false;
		}
		if(collision.gameObject.CompareTag("Wall") && !isGrounded){
			isHit = true;
            rb2D.AddForce(new Vector2((-horizontalMove/3) * Time.fixedDeltaTime, -2));
		}
	}
}
