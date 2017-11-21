using System.Collections;
using UnityEngine;

public class PlayerPistolShooter : MonoBehaviour {

	public float hitForce = 100f;
	public float damagePerHit = 10f;
	public float rateOfFire = 0.14f;
    public float rateOfTurn = 1.5f;
    public Transform gunEnd;
	public Camera fpsCamera;

	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private WaitForSeconds rateOfFireDuration;

    private LineRenderer laserLine;
	private float nextShotTime;

	private Vector3 centerScreenVector = new Vector3(0.5f, 0.5f, 0);
	private float weaponRange = 10000f;

    private Transform Munition;
	private float OriginalRotation;
	private int rotationCount = 0;

    // Use this for initialization
    void Start () {
		laserLine = GetComponent<LineRenderer> ();
        Munition = transform.FindChild("Munition");
        rateOfFireDuration = new WaitForSeconds(rateOfFire);
		OriginalRotation = transform.rotation.z;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time <= nextShotTime)
        {
			RotateMunition();
		}
		RotateRecoil ();
    }

	public void Fire()
	{
		if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + rateOfFire;

            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.ViewportToWorldPoint(centerScreenVector), fpsCamera.transform.forward, out hit, weaponRange))
            {
                fireBullet(hit.point);
                ApplyDamage(hit);
            }
            else
            {
                fireBullet(fpsCamera.transform.forward * weaponRange);
            }
        }
    }

    void ApplyDamage(RaycastHit hit)
    {
		var shootable = hit.collider.GetComponent(typeof(Shootable)) as Shootable;

        if (shootable != null)
        {
            shootable.Damage(hit, damagePerHit, hitForce);
        }
        
    }

    void fireBullet(Vector3 hitPoint)
    {
        laserLine.SetPosition(0, gunEnd.position);
        laserLine.SetPosition(1, hitPoint);
        StartCoroutine(ShotEffect());
    }

    void RotateMunition()
    {
        Munition.Rotate(rateOfTurn, 0, 0);
    }

	void RotateRecoil()
	{
		if (Time.time <= nextShotTime - (rateOfFire / 2)) {
			transform.Rotate (0, 0, -(rateOfTurn * 2));
			rotationCount++;
		} else if (rotationCount > 0) {
			transform.Rotate (0, 0, (rateOfTurn * 2)); 
			rotationCount--;
		}
	}

    IEnumerator ShotEffect()
	{       
        laserLine.enabled = true;
		yield return shotDuration;
		laserLine.enabled = false;
	}
}
