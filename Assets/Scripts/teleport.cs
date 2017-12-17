using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject newRoom;

    private void OnTriggerEnter(Collider other)
    {
        if (newRoom != null && other.name == "Camera (eye)")
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
    }
}
