using UnityEngine;

public class ButtonConvert : MonoBehaviour {

    public ManageBitcoins mbt;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name != "Camera (eye)" && other.gameObject.name != "Controller (left)" && other.gameObject.name != "Controller (right)")
        {
            valueObject value = other.gameObject.GetComponent<valueObject>();
            mbt.convert((value != null) ? (value.value) : (0));
            Destroy(other.gameObject);
        }
    }
}
