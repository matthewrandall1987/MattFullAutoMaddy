using UnityEngine;
using System.Collections;

public abstract class EnemyShooter : MonoBehaviour
{
	public float hitForce = 100f;
	public float damagePerHit = 10f;
	public float rateOfFire = 0.5f;
	public float rateOfTurn = 1.5f;
	public Transform gunEnd;
	public Transform head;
	public float inaccuracyRange = 0.1f;

	protected WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
	protected WaitForSeconds rateOfFireDuration;

	protected LineRenderer laserLine;
	protected float nextShotTime;
	protected float weaponRange = 10000f;

	// Use this for initialization
	void Start()
	{
		laserLine = GetComponent<LineRenderer>();
		rateOfFireDuration = new WaitForSeconds(rateOfFire);
	}

	protected virtual void ApplyDamage(RaycastHit hit)
	{
		var shootable = hit.collider.GetComponent<Shootable>();

		if (shootable != null)
		{
			shootable.Damage(hit, damagePerHit, hitForce);
		}

	}

	public abstract void Fire ();

	protected virtual void fireBullet(Vector3 hitPoint)
	{
		var inaccuracy = new Vector3(Random.Range(-inaccuracyRange, inaccuracyRange), Random.Range(-inaccuracyRange, inaccuracyRange), 0);

		laserLine.SetPosition(0, gunEnd.position);
		laserLine.SetPosition(1, hitPoint + inaccuracy);
		StartCoroutine(ShotEffect());
	}

	IEnumerator ShotEffect()
	{
		laserLine.enabled = true;
		yield return shotDuration;
		laserLine.enabled = false;
	}
}

