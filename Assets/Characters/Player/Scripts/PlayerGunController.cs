using UnityEngine;

public class PlayerGunController : MonoBehaviour {
	private GameObject _rightGun;
	private GameObject _leftGun;

    PlayerPistolShooter _rightIShoot;
    PlayerPistolShooter _leftIShoot;

	// Use this for initialization
	void Start () {
		_rightGun = GameObject.FindGameObjectWithTag ("RightGun");
		_rightIShoot = _rightGun.GetComponent<PlayerPistolShooter> ();

		_leftGun = GameObject.FindGameObjectWithTag ("LeftGun");
		_leftIShoot = _leftGun.GetComponent<PlayerPistolShooter> ();
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
