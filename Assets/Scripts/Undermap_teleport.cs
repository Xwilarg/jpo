using UnityEngine;

public class Undermap_teleport : MonoBehaviour
{
    private GameObject Totel;
    private Vector3 TotelPos;
    private void OnCollisionEnter(Collision other)
    {
        Totel = other.gameObject;
        TotelPos = Totel.transform.position;
        TotelPos.y = 1.5f;
        Totel.transform.position = TotelPos;
    }
}
