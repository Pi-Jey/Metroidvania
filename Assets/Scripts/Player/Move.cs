using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
    float HorizontalMove = 0f;
    bool jump = false;
    bool dash = false;
    public float runSpeed = 40f;

	void Update () 
	{

		HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

		if (Input.GetKeyDown(KeyCode.Z))
		{
			jump = true;
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			dash = true;
		}

	}
	public void OnFallilng()
	{
		animator.SetBool("IsJumping", true);
	}
	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}
	void FixedUpdate ()
	{
		controller.Move(HorizontalMove * Time.fixedDeltaTime, jump, dash);
		jump = false;
		dash = false;
	}
}
