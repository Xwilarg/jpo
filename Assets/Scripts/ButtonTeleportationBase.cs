using UnityEngine;

public class ButtonTeleportationBase : MonoBehaviour {

    public teleport portal;
    public GameObject destination;

    private void OnTriggerEnter(Collider other)
    {
        portal.enable(destination);
    }
}
