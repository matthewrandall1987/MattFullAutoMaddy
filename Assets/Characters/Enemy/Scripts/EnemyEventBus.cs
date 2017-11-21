using System;
using UnityEngine;

public class EnemyEventBus : MonoBehaviour
{
	public delegate void Handler();
	public event Handler HasDied;

	public void InvokeHasDied()
	{
		if (HasDied != null)
			HasDied.Invoke ();
	}

}


