using System;
using UnityEngine;

public class EnemyEventBus : MonoBehaviour
{
    private EnemySpecificEvents _enemySpecificEvents;

    public delegate void Handler();
	public event Handler HasDied;
    public event Handler HasReachedTarget;
    public event Handler Strike;
    public event Handler AwayFromTarget;

    private void Start()
    {
        _enemySpecificEvents = GameObject.FindGameObjectWithTag("EnemySpecificEvents").GetComponent<EnemySpecificEvents>();
    }

    public void InvokeHasDied()
	{
        if (HasDied != null)
			HasDied.Invoke ();

        _enemySpecificEvents.InvokeHasDied();
    }

    public void InvokeReachedTarget()
    {
        if (HasReachedTarget != null)
            HasReachedTarget.Invoke();
    }

    public void InvokeAwayFromTarget()
    {
        if (AwayFromTarget != null)
            AwayFromTarget.Invoke();
    }

    public void InvokeStrike()
    {
        if (Strike != null)
            Strike.Invoke();
    }

}


