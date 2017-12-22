using System.Linq;
using UnityEngine;

public class PlugUnplug : MonoBehaviour
{
    public Vector3[] allPos;
    public Vector3[] allRot;
    public string[] allName;
    private Rigidbody rb;
    public ControllerGrab cr, cl;
    public bool startOut;

    private float counterTake;

    private void Start()
    {
        Debug.Assert(allPos.Length == allRot.Length && allPos.Length == allName.Length);
        rb = GetComponent<Rigidbody>();
        counterTake = 0f;
    }

    private void Update()
    {
        if (counterTake > 0f)
            counterTake -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (counterTake > 0f) return;
        for (int i = 0; i < allName.Length; i++)
        {
            if (allName[i] == other.name)
            {
                if (!startOut)
                {
                    startOut = true;
                    return;
                }
                if (cl != null && cl.getObjName() == name) cl.drop();
                if (cr != null && cr.getObjName() == name) cr.drop();
                transform.rotation = other.transform.rotation * Quaternion.Euler(allRot[i]);
                transform.parent = other.transform;
                transform.position = other.transform.position + allPos[i];
                if (name == "UsbKey")
                    Destroy(GetComponent<Rigidbody>());
                else
                    rb.isKinematic = true;
                break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        counterTake = 0.5f;
    }
}
