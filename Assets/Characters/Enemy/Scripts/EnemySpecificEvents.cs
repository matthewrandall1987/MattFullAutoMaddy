using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecificEvents : MonoBehaviour {

    public delegate void Handler();
    public event Handler HasDied;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InvokeHasDied()
    {
        if (HasDied != null)
            HasDied.Invoke();
    }
}
