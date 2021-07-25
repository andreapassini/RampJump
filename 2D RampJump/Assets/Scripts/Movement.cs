using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] float speed = 100f;
	[SerializeField] float jumpForce;
	private float input;
	private bool isJumping, isGrounded;

	private Rigidbody2D rb;

	[SerializeField] LayerMask whatIsGround;
	[SerializeField] Transform groundCheck;
	const float groundedRadius = .2f;


	private void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		isJumping = false;
		isGrounded = false;
	}

	private void Update()
	{
		input = Input.GetAxisRaw("Horizontal");
		//Potrei anche usare un vettore normalizzato

		Flip(input);

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			isJumping = true;
		}
	}

	private void FixedUpdate()
	{
		//Controllo che il Player non sia in aria
		isGrounded = false;
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);

		rb.velocity = new Vector2(input * speed, rb.velocity.y);

		if (isJumping) {
			//rb.velocity = Vector2.up * jumpForce;
			rb.AddForce(transform.up * (jumpForce), ForceMode2D.Impulse);
			isJumping = false;
		}
	}



	private void Flip(float input)
	{
		if (input > 0) {
			transform.eulerAngles = new Vector3(0, 0, 0);
		} else if (input < 0) {
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
	}
}
