using UnityEngine;

public class LoadUsbKey : MonoBehaviour {
    
    private CheckPwd cpwd;

    private void Start()
    {
        cpwd = transform.parent.GetComponent<CheckPwd>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "UsbKey")
        {
            cpwd.display(other.GetComponent<UsbContent>().key);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "UsbKey")
        {
            cpwd.unDisplay();
        }
    }
}
