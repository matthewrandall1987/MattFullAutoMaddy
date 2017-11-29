using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void Interact(RaycastHit hit, float force);
}
