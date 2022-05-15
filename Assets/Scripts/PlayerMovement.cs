using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float tapSpeed = 0.3f;
    [SerializeField] private float maxJumpForce = 650f;	// Amount of force added when the player jumps.
    [SerializeField] private float horizontalJumpForce = 350f;
    [SerializeField] private float maxChargeTime = 1.5f;
    [SerializeField] private float minChargeTime = 0.2f;
    //linear function to calculate jump power y=mx+b
    //jumpFunctionSlope is m
    private float jumpFunctionSlope = 250f;
    private float jumpFunctionConstant = 275f;
	private Rigidbody2D rb2D;
    private bool isGrounded; //Whether or not the character is touching the ground
	private bool isHit;
	private bool facingRight = true;  // For determining which way the player is currently facing.
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool maxCharge = false;
    [SerializeField]private float buttonTimer = 0f;
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
			isGrounded = true;
            isHit = false;
		}
		if(collision.gameObject.CompareTag("Wall") && !isGrounded){
			isHit = true;
		}
	}
}
