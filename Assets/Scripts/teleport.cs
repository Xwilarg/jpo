using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject newRoom;
    private MeshRenderer mr;
    private CapsuleCollider cc;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        cc = GetComponent<CapsuleCollider>();
    }

    public void enable()
    {
        mr.enabled = true;
        cc.enabled = true;
    }

    public void enable(GameObject destination)
    {
        newRoom = destination;
        enable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (newRoom != null && (other.name == "Camera (eye)" || other.name == "Controller (left)" || other.name == "Controller (right)"))
            GameObject.Find("[CameraRig]").transform.position = newRoom.transform.position;
        else
        {
            other.transform.position = newRoom.transform.position;

            GameObject controllerL = GameObject.Find("Controller (left)");
            GameObject controllerR = GameObject.Find("Controller (right)");
            if (controllerL != null)
                controllerL.GetComponent<ControllerGrab>().drop();
            if (controllerR != null)
                controllerR.GetComponent<ControllerGrab>().drop();
        }
        mr.enabled = false;
        cc.enabled = false;
    }
}
