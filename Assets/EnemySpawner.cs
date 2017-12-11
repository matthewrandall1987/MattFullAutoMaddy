using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour {

    Transform[] SpawnPoints;
    public GameObject Zombie;
    public GameObject ZombieContainer;
    private EnemySpecificEvents _enemySpecificEvents;

    // Use this for initialization
    void Start () {
        SpawnPoints = transform.GetComponentsInChildren<Transform>();
        _enemySpecificEvents = GameObject.FindGameObjectWithTag("EnemySpecificEvents").GetComponent<EnemySpecificEvents>();
        _enemySpecificEvents.HasDied += enemySpecificEvents_HasDied;
	}

    private void enemySpecificEvents_HasDied()
    {
        var randomSpawnPoint = Random.Range(0, SpawnPoints.Length - 1);
        
        var zombie = Instantiate(Zombie, SpawnPoints[randomSpawnPoint].position, Zombie.transform.rotation, ZombieContainer.transform);
        
    }
}
