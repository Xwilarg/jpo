using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugUnplug : MonoBehaviour
{
    public Vector3 plugPos;
    public string targetName;
    private bool startIn;
    private Rigidbody rb;
    public ControllerGrab cr, cl;

    private void Start()
    {
        startIn = false;
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == targetName)
        {
            if (!startIn)
            {
                startIn = true;
                return;
            }
            if (cl != null && cl.getObjName() == name) cl.drop();
            if (cr != null && cr.getObjName() == name) cr.drop();
            transform.position = plugPos;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            rb.isKinematic = true;
        }
    }
}
