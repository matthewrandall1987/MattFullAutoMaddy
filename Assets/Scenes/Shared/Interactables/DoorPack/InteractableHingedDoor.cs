using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHingedDoor : Interactable {
    private Animator _animator;
    int closedHash;
    int openHash;

    // Use this for initialization
    void Start () {
        _animator = GetComponentInParent<Animator>();
        closedHash = Animator.StringToHash("Closed");
        openHash = Animator.StringToHash("Open");
	}
	
	// Update is called once per frame
	void Update () {

    }

    public override void Interact(RaycastHit hit, float force)
    {
        _animator.SetBool("open", !_animator.GetBool("open"));
    }
}
