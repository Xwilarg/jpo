using UnityEngine;

public class UnplugComputer : MonoBehaviour {

    private CheckPwd cpwd;
    private bool startIn;

    private void Start()
    {
        startIn = false;
        cpwd = transform.parent.GetComponent<CheckPwd>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WireComputer")
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
        if (other.name == "WireComputer")
        {
            cpwd.switchOnOff(false);
        }
    }
}
