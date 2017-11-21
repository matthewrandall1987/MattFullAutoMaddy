using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPoints : Shootable {

	public float HitPoints = 30;

	private EnemyEventBus EventBus;

	// Use this for initialization
	void Start () {
		EventBus = GetComponent<EnemyEventBus> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Damage (RaycastHit hit, float damagePerHit, float hitForce)
	{
		HitPoints -= damagePerHit;

		if (HitPoints <= 0)
			EventBus.InvokeHasDied();
		
		base.Damage (hit, damagePerHit, hitForce);
	}
}
