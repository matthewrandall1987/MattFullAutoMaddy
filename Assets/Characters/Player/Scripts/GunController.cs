using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	private GameObject _rightGun;
	private GameObject _leftGun;

	Shooter _rightIShoot;
    Shooter _leftIShoot;

	// Use this for initialization
	void Start () {
		_rightGun = GameObject.FindGameObjectWithTag ("RightGun");
		_rightIShoot = _rightGun.GetComponent<Shooter> ();

		_leftGun = GameObject.FindGameObjectWithTag ("LeftGun");
		_leftIShoot = _leftGun.GetComponent<Shooter> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton ("Fire1")) {
			_rightIShoot.Fire ();
		}

		if (Input.GetButton ("Fire2")) {
			_leftIShoot.Fire ();
		}
	}
}
