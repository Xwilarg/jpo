using UnityEngine;

public class ButtonConvert : MonoBehaviour {

    public ManageBitcoins mbt;

    private void OnCollisionEnter(Collider other)
    {
        if (other.name != "Camera (eye)" && other.name != "Controller (left)" && other.name != "Controller (right)")
        {
            mbt.convert(name.Length * 100);
            Destroy(other.gameObject);
        }
    }
}
