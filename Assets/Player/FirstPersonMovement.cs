using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour {

	public float speed = 6.0F;
	public float sprintSpeed = 9.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private CharacterController controller;

	void Start() {

		controller = GetComponent<CharacterController>();
	}

	void Update() {
		var moveDirection = GetMovementDirection ();
		moveDirection *= GetMovementSpeed();
		ApplyJumpAndFall (ref moveDirection);

		controller.Move(moveDirection * Time.deltaTime);
	}

	Vector3 GetMovementDirection()
	{
		if (controller.isGrounded)
			return transform.TransformDirection (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		else
			return controller.velocity;
	}

	float GetMovementSpeed()
	{
		if (controller.isGrounded)
			if (isMovingForward ())
				if (Input.GetButton ("Sprint"))
					return sprintSpeed;
				else
					return speed;
			else
				return speed / 2;
		else
			return 1;
	}

	bool isMovingForward()
	{
		return Input.GetAxis ("Vertical") >= 0;
	}

	void ApplyJumpAndFall(ref Vector3 moveDirection)
	{
		if (controller.isGrounded) 
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;

		moveDirection.y -= gravity * Time.deltaTime;
	}
}
