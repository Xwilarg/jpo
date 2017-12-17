using UnityEngine;

public class teleport : MonoBehaviour {

    public GameObject newRoom;

    private void OnTriggerEnter(Collider other)
    {
        if (newRoom != null && other.name == "Camera (eye)")
            GameObject.Find("[CameraRig]").transform.position = newRoom.transform.position;
    }
}
