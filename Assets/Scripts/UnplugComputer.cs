using UnityEngine;

public class UnplugComputer : MonoBehaviour {

    private CheckPwd cpwd;
    private Rigidbody rb;
    private bool startIn;

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
            cpwd.switchOnOff(true);
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
