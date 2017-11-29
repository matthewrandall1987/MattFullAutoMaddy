using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeShootable : Shootable {

    public float ApplyForce = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Damage(RaycastHit hit, float damagePerHit, float hitForce)
    {
        base.Damage(hit, damagePerHit, ApplyForce);
    }
}
