using UnityEngine;

public class triggerButton : MonoBehaviour {

    private const float trigger = -0.009f;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 newPos = transform.position;
        newPos.y += trigger;
        transform.position = newPos;
    }

    private void OnTriggerExit(Collider other)
    {
        Vector3 newPos = transform.position;
        newPos.y -= trigger;
        transform.position = newPos;
    }
}
