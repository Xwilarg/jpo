using UnityEngine;

public class ButtonBuy : MonoBehaviour {

    public ManageBitcoins mbt;

    private void OnTriggerEnter(Collider other)
    {
        mbt.buy();
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnTriggerEnter(collision.collider);
    }
}
