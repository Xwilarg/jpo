using UnityEngine;

public class GiveImpulse : MonoBehaviour {

    public ControllerGrab cr, cl;

    private const float multiplicator = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Grappable"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if (cl != null && cl.getObjName() == name) rb.velocity = cl.getVelocity() * multiplicator;
                else if (cr != null && cr.getObjName() == name) rb.velocity = cr.getVelocity() * multiplicator;
            }
        }
    }
}
