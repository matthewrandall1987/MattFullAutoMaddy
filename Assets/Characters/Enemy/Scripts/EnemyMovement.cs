using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    private GameObject _target;
    private NavMeshAgent _meshMeshAgent;
	private EnemyEventBus eventBus;
    private bool isDead;

    // Use this for initialization
    void Start () {

        _meshMeshAgent = GetComponent<NavMeshAgent>();
        NavMeshHit closestHit;

        if (NavMesh.SamplePosition(transform.position, out closestHit, 500, 1))
            _meshMeshAgent.Warp(transform.position = closestHit.position);

        _meshMeshAgent.enabled = false;

        _target = GameObject.FindGameObjectWithTag("Player");
		eventBus = GetComponent<EnemyEventBus> ();
		eventBus.HasDied += Died;
    }
	
	// Update is called once per frame
	void Update () {
        _meshMeshAgent.enabled = true;

        _meshMeshAgent.destination = _target.transform.position;

        if (!_meshMeshAgent.pathPending && 
            _meshMeshAgent.remainingDistance <= _meshMeshAgent.stoppingDistance && 
            (!_meshMeshAgent.hasPath || _meshMeshAgent.velocity.sqrMagnitude == 0f))
        {
            eventBus.InvokeReachedTarget();

            RotateTowardTargetWhileClose();
        }
        else
        {
            eventBus.InvokeAwayFromTarget();
        }
    }

    private void RotateTowardTargetWhileClose()
    {
        Vector3 newDir = Vector3.RotateTowards(transform.forward, _target.transform.position - transform.position, 0f, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void Died()
    {
        _meshMeshAgent.isStopped = true;

        foreach (var component in gameObject.GetComponents<MonoBehaviour>())
            component.enabled = false;

        enabled = false;
	}
}
