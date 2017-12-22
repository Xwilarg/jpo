using UnityEngine;

public class UnplugComputer : MonoBehaviour {

    private CheckPwd cpwd;
    private Rigidbody rb;
    private readonly Vector3 plugPos = new Vector3(11.705f, 0.113f, 0.3530003f);
    private bool startIn;
    public ControllerGrab cr, cl;

    private void Start()
    {
        startIn = false;
        cpwd = transform.parent.GetComponent<CheckPwd>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlugComputer")
        {
            if (!startIn)
            {
                startIn = true;
                return;
            }
            if (cl != null && cl.getObjName() == name) cl.drop();
            if (cr != null && cr.getObjName() == name) cr.drop();
            cpwd.switchOnOff(true);
            transform.position = plugPos;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            rb.isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlugComputer")
        {
            cpwd.switchOnOff(false);
        }
    }
}
