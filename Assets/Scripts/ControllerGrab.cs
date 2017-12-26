using System.Collections.Generic;
using UnityEngine;

public class ControllerGrab : MonoBehaviour {

    private SteamVR_TrackedController controller;

    private List<GameObject> grappable;
    private GameObject currGrab;
    private Vector3 lastPos, newPos;
    public TaserCloser taserCloser;

    private void GrabObject(object sender, ClickedEventArgs e)
    {
        if (grappable.Count > 0)
        {
            currGrab = grappable[0];
            taserCloser.drop(currGrab);
            Rigidbody rb = currGrab.GetComponent<Rigidbody>();
            if (currGrab.name == "UsbKey" && rb == null)
            {
                currGrab.AddComponent<Rigidbody>();
                rb = currGrab.GetComponent<Rigidbody>();
            }
            else if (currGrab.name == "Flamethrower")
            {
                currGrab.GetComponent<ParticleSystem>().Play();
            }
            else if (currGrab.name == "Phaser")
            {
                currGrab.GetComponent<Taser>().enabled = true;
                currGrab.GetComponent<LineRenderer>().enabled = true;
            }
            else if (currGrab.name == "Phaser2")
            {
                currGrab.GetComponent<TaserCloser>().enabled = true;
                currGrab.GetComponent<LineRenderer>().enabled = true;
            }
            else if (currGrab.name == "UFO")
            {
                currGrab.GetComponent<MoveCar>().isEnable = false;
            }
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

    public Vector3 getVelocity()
    {
        return ((newPos - lastPos) * 100f);
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
            if (currGrab.name == "Flamethrower")
            {
                currGrab.GetComponent<ParticleSystem>().Stop();
            }
            else if (currGrab.name == "Phaser")
            {
                currGrab.GetComponent<Taser>().enabled = false;
                currGrab.GetComponent<LineRenderer>().enabled = false;
            }
            else if (currGrab.name == "Phaser2")
            {
                TaserCloser tc = currGrab.GetComponent<TaserCloser>();
                tc.stop();
                tc.enabled = false;
                currGrab.GetComponent<LineRenderer>().enabled = false;
            }
            currGrab.transform.parent = null;
            currGrab = null;
            grappable = new List<GameObject>();
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

    private void Start ()
    {
        currGrab = null;
        lastPos = Vector3.zero;
        newPos = Vector3.zero;
        grappable = new List<GameObject>();
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += GrabObject;
        controller.TriggerUnclicked += DropObject;
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
