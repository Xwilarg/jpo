using UnityEngine;

public class CallGoDown : MonoBehaviour {

    ButtonDisparition bd;

    private void Start()
    {
        bd = GetComponentInParent<ButtonDisparition>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnTriggerEnter(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        bd.goDown();
    }
}
