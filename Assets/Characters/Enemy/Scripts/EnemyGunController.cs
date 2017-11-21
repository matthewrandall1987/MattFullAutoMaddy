using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour {
    
	private EnemyShooter _shooter;

    public GameObject Head;
    public GameObject Body;
	public GameObject Gun;
    public float RotateSpeed = 0.1f;
    public float headOffset = 1;

	private EnemyEventBus eventBus;
    private GameObject _target;

    // Use this for initialization
    void Start()
    {
		_shooter = Gun.GetComponent<EnemyShooter>();
        _target = GameObject.FindGameObjectWithTag("Player");
		eventBus = GetComponent<EnemyEventBus> ();
		eventBus.HasDied += new EnemyEventBus.Handler (Died);
    }
            
    void Update()
    {

        var ytargetPosition = _target.transform.position;
        ytargetPosition.y += headOffset;

        Head.transform.LookAt(ytargetPosition, _target.transform.up);

        var xtargetPostion = _target.transform.position;
        xtargetPostion.y = Body.transform.position.y;
        Body.transform.LookAt(xtargetPostion, _target.transform.up);

        _shooter.Fire();
    }

	void Died()
	{
		this.enabled = false;
	}
}
