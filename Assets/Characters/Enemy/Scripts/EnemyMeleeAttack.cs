using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour {
    private EnemyEventBus _eventBus;
    private GameObject _target;
    private PlayerHitPoints _targetHitPoints;

    public float Damage = 5f;

    // Use this for initialization
    void Start () {
        _eventBus = GetComponent<EnemyEventBus>();
        _eventBus.Strike += eventBus_Strike;
        _target = GameObject.FindGameObjectWithTag("Player");
        _targetHitPoints = _target.GetComponent<PlayerHitPoints>();
    }

    private void eventBus_Strike()
    {
        _targetHitPoints.Strike(Damage);
    }

    // Update is called once per frame
    void Update () {
		
	}    
}
