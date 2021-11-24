using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
	[SerializeField] float runSpeed = 100f;
	[SerializeField] float jumpForce;
	private float horizontalMove;
	private bool isJumping, isGrounded;

	private Rigidbody2D rb;
	public Animator animator;

	[SerializeField] LayerMask whatIsGround;
	[SerializeField] Transform groundCheck;
	const float groundedRadius = .2f;
	private bool grounded; // Whether or not the player is grounded.

	private bool m_FacingRight = true;  // For determining which way the player is currently facing.

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	private void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		isJumping = false;
		isGrounded = false;
	}

	private void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		//Potrei anche usare un vettore normalizzato

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump") && isGrounded) {
			isJumping = true;
			animator.SetBool("IsJumping", true);
		}
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	private void FixedUpdate()
	{
		//Controllo che il Player non sia in aria
		isGrounded = false;
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);

		rb.velocity = new Vector2(horizontalMove * Time.deltaTime, rb.velocity.y);

		if (isJumping) {
			
			rb.AddForce(transform.up * (jumpForce), ForceMode2D.Impulse);
			//rb.AddForce(new Vector2(0f, jumpForce));
			isJumping = false;
		}

		// If the input is moving the player right and the player is facing left...
		if (horizontalMove > 0 && !m_FacingRight) {
			// ... flip the player.
			Flip();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (horizontalMove < 0 && m_FacingRight) {
			// ... flip the player.
			Flip();
		}

		bool wasGrounded = grounded;
		grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject) {
				grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}



	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		transform.Rotate(0f, 180f, 0f);
	}
}
