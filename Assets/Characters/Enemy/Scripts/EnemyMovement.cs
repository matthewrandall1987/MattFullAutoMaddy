using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    private GameObject _target;
    private NavMeshAgent _agent;
	private EnemyEventBus eventBus;

    // Use this for initialization
    void Start () {

        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player");
		eventBus = GetComponent<EnemyEventBus> ();
		eventBus.HasDied += new EnemyEventBus.Handler (Died);
    }
	
	// Update is called once per frame
	void Update () {
        _agent.destination = _target.transform.position;
    }


	void Died()
	{
		this.enabled = false;
	}
}
