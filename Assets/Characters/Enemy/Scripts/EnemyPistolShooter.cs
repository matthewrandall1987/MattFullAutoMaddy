using System.Collections;
using UnityEngine;

public class EnemyPistolShooter : EnemyShooter
{
    private Transform Munition;

    // Use this for initialization
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        rateOfFireDuration = new WaitForSeconds(rateOfFire);

		Munition = transform.FindChild("Munition");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time <= nextShotTime)
        {
            RotateMunition();
        }
    }

    public override void Fire()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + rateOfFire;
            
            RaycastHit hit;
            if (Physics.Raycast(head.position, head.forward, out hit, weaponRange))
            {
                fireBullet(hit.point);
                ApplyDamage(hit);
            }
            else
            {
                fireBullet(gunEnd.forward * weaponRange);
			}

			RotateMunition();
        }
	}

	void RotateMunition()
	{
		Munition.Rotate(rateOfTurn, 0, 0);
	}
}

