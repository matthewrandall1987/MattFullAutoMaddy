using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    public Camera fpsCamera;
    public float Range = 10f;
    public float InteractForce = 10f;
    public LayerMask layers;

    private Vector3 centerScreenVector = new Vector3(0.5f, 0.5f, 0);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.ViewportToWorldPoint(centerScreenVector), fpsCamera.transform.forward, out hit, Range))
        {
            var interactable = hit.collider.GetComponentInParent(typeof(Interactable)) as Interactable;
            
            // print on screen

            if (interactable != null && Input.GetButton("Interact"))
            {
                interactable.Interact(hit, InteractForce);
            }
        }
    }
}
