using System.Collections.Generic;
using UnityEngine;

public class ControllerGrab : MonoBehaviour {

    private SteamVR_TrackedController controller;

    private List<GameObject> grappable;
    private GameObject currGrab;
    private Vector3 lastPos, newPos;

    public GameObject portails;

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
            rb.velocity = (newPos - lastPos) * 100f;
            drop();
        }
    }

    public string getObjName()
    {
        if (currGrab == null) return (null);
        else return (currGrab.name);
    }

    public void drop()
    {
        if (currGrab != null)
        {
            Rigidbody rb = currGrab.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;
            currGrab.transform.parent = null;
            currGrab = null;
        }
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

    private void teleportRoom(object sender, ClickedEventArgs e)
    {
        portails.SetActive(true);
    }

    private void Start ()
    {
        currGrab = null;
        lastPos = Vector3.zero;
        newPos = Vector3.zero;
        grappable = new List<GameObject>();
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += GrabObject;
        controller.TriggerUnclicked += DropObject;
        controller.PadClicked += teleportRoom;
	}


    public void Update()
    {
        if (currGrab != null)
        {
            lastPos = newPos;
            newPos = transform.position;
        }
    }
}
