using UnityEngine;

public class PlugUnplug : MonoBehaviour
{
    public Vector3 plugPos, plugRot;
    public string targetName;
    private Rigidbody rb;
    public ControllerGrab cr, cl;
    public bool startOut;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == targetName)
        {
            if (!startOut)
            {
                startOut = true;
                return;
            }
            if (cl != null && cl.getObjName() == name) cl.drop();
            if (cr != null && cr.getObjName() == name) cr.drop();
            transform.position = plugPos;
            transform.rotation = Quaternion.Euler(plugRot);
            rb.isKinematic = true;
        }
    }
}
