using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowShootable : Shootable {

    public GameObject brokenObject;
    public int magnitudeRequiredToBreak = 12;
    
    public Quaternion RotationFix = new Quaternion(0.7f, 0.0f, 0.0f, 0.7f);

    public float ExplosionRadius = 1;
    public LayerMask Layers;

    public float CleanupShardsTime = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Damage(RaycastHit hit, float damagePerHit, float hitForce)
    {
        DestroyAndMakeBreakObject();
        
        Collider[] objects = Physics.OverlapSphere(hit.point, ExplosionRadius, Layers);

        var breakingObject = DestroyAndMakeBreakObject();

        foreach (Collider h in objects)
        {
            Rigidbody r = h.GetComponent<Rigidbody>();
            if (r != null)
                r.AddExplosionForce(hitForce, ((hit.point - breakingObject.transform.position) * 0.5f) + breakingObject.transform.position, ExplosionRadius);
        }
        
    }

    private GameObject DestroyAndMakeBreakObject()
    {
        var rotate = transform.rotation * Quaternion.Inverse(RotationFix);

        GameObject breakingObject = Instantiate(brokenObject, transform.position, rotate);
        breakingObject.transform.localScale = transform.localScale;

        Destroy(gameObject);
        Destroy(breakingObject, CleanupShardsTime);

        return breakingObject;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > magnitudeRequiredToBreak)
        {
            DestroyAndMakeBreakObject();
        }
    }
}
