using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplode : Shootable {

    public GameObject ExplosionDescription;
    public LayerMask Layers;

    public float explosionRadius = 5f;
    public float explosionForce = 100f;

    private GameObject _explosion;
    private ParticleSystem _explosionParticleSystem;
    private WaitForSeconds _explosionDuration;


    // Use this for initialization
    void Start () {
        _explosion = Instantiate(ExplosionDescription);
        _explosionParticleSystem = _explosion.GetComponent<ParticleSystem>();
        _explosionDuration = new WaitForSeconds(_explosionParticleSystem.main.duration / 2);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public override void Damage(RaycastHit hit, float damagePerHit, float hitForce)
    {
        base.Damage(hit, damagePerHit, hitForce);

        _explosionParticleSystem.Play();

        var position = transform.GetChild(0).position;

        Collider[] objects = Physics.OverlapSphere(position, explosionRadius, Layers);

        foreach (Collider h in objects)
        {
            Rigidbody r = h.GetComponent<Rigidbody>();
            if (r != null)
                r.AddExplosionForce(explosionForce, position, explosionRadius);
        }

        StartCoroutine(DestoryMe());
    }

    IEnumerator DestoryMe()
    {
        Destroy(gameObject);
        yield return _explosionDuration;
        Destroy(_explosion);        
    }
}
