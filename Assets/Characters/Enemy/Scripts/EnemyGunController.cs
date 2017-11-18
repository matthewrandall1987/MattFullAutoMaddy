using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour {
    private GameObject _gun;
    private EnemyPistolShooter _shooter;

    public GameObject Head;
    public GameObject Body;
    public float RotateSpeed = 0.1f;
    public float headOffset = 1;

    private GameObject _target;

    // Use this for initialization
    void Start()
    {
        _gun = transform.GetChild(0).gameObject;
        _shooter = _gun.GetComponent<EnemyPistolShooter>();
        _target = GameObject.FindGameObjectWithTag("Player");
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

}
