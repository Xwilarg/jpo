using System.Linq;
using UnityEngine;

public class PlugUnplug : MonoBehaviour
{
    public Vector3 plugPos, plugRot;
    public string[] targetName;
    private Rigidbody rb;
    public ControllerGrab cr, cl;
    public bool startOut;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetName.Contains(other.name))
        {
            if (!startOut)
            {
                startOut = true;
                return;
            }
            if (cl != null && cl.getObjName() == name) cl.drop();
            if (cr != null && cr.getObjName() == name) cr.drop();
            transform.rotation = other.transform.rotation * Quaternion.Euler(plugRot);
            transform.parent = other.transform;
            transform.position = other.transform.position + plugPos;
            rb.isKinematic = true;
        }
    }
}
