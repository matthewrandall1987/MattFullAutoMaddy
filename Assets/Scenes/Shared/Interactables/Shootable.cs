using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shootable : MonoBehaviour {

	public virtual void Damage(RaycastHit hit, float damagePerHit, float hitForce)
    {
        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * hitForce);
        }
    }
}
