using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookMovement : MonoBehaviour {

	public float sensitivityX = 8f;
	public float sensitivityY = 8f;

	public float mininumY = -60f;
	public float maximumY = 60f;

	float rotationX;
	float rotationY;

	Transform headTransform;
	Quaternion headStartingRotation;
	Quaternion bodyStartingRotation;

	// Use this for initialization
	void Start () {
		headTransform = transform.FindChild ("Head");
		headStartingRotation = headTransform.localRotation;
		bodyStartingRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		rotationX += Input.GetAxis ("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;

		rotationX = ClampAngle (rotationX);
		rotationY = ClampAngle (rotationY, mininumY, maximumY);

		Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
		Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);

		headTransform.localRotation = headStartingRotation * yQuaternion;
		transform.localRotation = bodyStartingRotation * xQuaternion;
	}

	private static float ClampAngle (float angle, float min = -360f, float max = 360f)
	{
		if (angle == -360F)
			angle += 360F;

		if (angle == 360F)
			angle -= 360F;
		
		return Mathf.Clamp (angle, min, max);
	}
}
