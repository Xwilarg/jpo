using System.Collections.Generic;
using UnityEngine;

public class ControllerGrab : MonoBehaviour {

    private SteamVR_TrackedController controller;

    private List<GameObject> grappable;
    private GameObject currGrab;
    private Vector3 lastPos;

    private void GrabObject(object sender, ClickedEventArgs e)
    {
        if (grappable.Count > 0)
        {
            currGrab = grappable[0];
            Rigidbody rb = currGrab.GetComponent<Rigidbody>();
            currGrab.transform.parent = transform;
            rb.isKinematic = true;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
        }
    }

    private void DropObject(object sender, ClickedEventArgs e)
    {
        if (currGrab != null)
        {
            Rigidbody rb = currGrab.GetComponent<Rigidbody>();
            rb.velocity = (transform.position - lastPos) * 10f;
            drop();
        }
    }

    public void drop()
    {
        Rigidbody rb = currGrab.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        currGrab.transform.parent = null;
        currGrab = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grappable"))
            grappable.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grappable"))
            grappable.Remove(other.gameObject);
    }

    private void Start ()
    {
        currGrab = null;
        lastPos = Vector3.zero;
        grappable = new List<GameObject>();
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += GrabObject;
        controller.TriggerUnclicked += DropObject;
	}


    public void Update()
    {
        if (currGrab != null)
        {
            lastPos = transform.position;
        }
    }
}
