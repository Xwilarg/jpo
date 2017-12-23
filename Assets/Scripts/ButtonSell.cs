using UnityEngine;

public class ButtonSell : MonoBehaviour {

    public ManageBitcoins mbt;

    private void OnTriggerEnter(Collider other)
    {
        mbt.sell();
    }
}
