using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	public static float haosLom;
	public static float haosMax;
	public static float time;
	public static float score;
	public static bool umro;


	public Rigidbody2D rb;
	public Transform groundCheckLeft;
	public Transform groundCheckRight;
	public LayerMask groundLayer;
	public float ms = 8f;
	public float jumpingPower = 16f;
	public Collider2D colider;

	private bool canJump = true;
	private bool isFacingLeft = false;
	private bool isFacingRight = true;
	private float horizontal;

	void Start()
	{

	}

	void FixedUpdate()
	{

		if (!isFacingRight && horizontal > 0f) Flip();
		else if (isFacingRight && horizontal < 0f) Flip();

	}

	private void Update()
	{
	
	}

	private bool IsGrounded()
	{
		return Physics2D.OverlapCircle(groundCheckLeft.position, 0.02f, groundLayer) || Physics2D.OverlapCircle(groundCheckRight.position, 0.02f, groundLayer);
	}

	public void Move(InputAction.CallbackContext context)
	{
		if (context.ReadValue<Vector2>().x > 0) horizontal = 1;
		else if (context.ReadValue<Vector2>().x < 0) horizontal = -1;
		else horizontal = 0;
	}

	public void Jump(InputAction.CallbackContext context)
	{
		if (context.performed && canJump)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
		}

		if (context.canceled && rb.velocity.y > 0f)
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
		}
	}

	private void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 localScale = transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	public void Click1(InputAction.CallbackContext context)
	{
		print("sdfhijofgsdhj");
	}

}
