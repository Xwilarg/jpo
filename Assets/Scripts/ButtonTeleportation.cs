using UnityEngine;

public class ButtonTeleportation : MonoBehaviour {

    public teleport portal;

    private void OnTriggerEnter(Collider other)
    {
        portal.enable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnTriggerEnter(collision.collider);
    }
}
