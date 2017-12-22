using UnityEngine;

public class PlugUnplug : MonoBehaviour
{
    public Vector3[] allPos;
    public Vector3[] allRot;
    public string[] allName;
    private Rigidbody rb;
    public ControllerGrab cr, cl;
    public bool startOut;

    private void Start()
    {
        Debug.Assert(allPos.Length == allRot.Length && allPos.Length == allName.Length);
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
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
                rb.isKinematic = true;
                break;
            }
        }
    }
}
