using UnityEngine;
using System.Linq;

public class teleport : MonoBehaviour
{
    public GameObject newRoom;
    private MeshRenderer mr;
    private CapsuleCollider cc;
    public MeshRenderer textBitcoin;
    private GameObject radio;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        cc = GetComponent<CapsuleCollider>();
        radio = GameObject.Find("Radio");
    }

    public void enable()
    {
        mr.enabled = true;
        cc.enabled = true;
    }

    public void enable(GameObject destination)
    {
        newRoom = destination;
        enable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (newRoom != null && (other.name == "Camera (eye)" || other.name == "Controller (left)" || other.name == "Controller (right)"))
        {
            GameObject.Find("[CameraRig]").transform.position = newRoom.transform.position;
            if (newRoom.name == "Placard")
                textBitcoin.enabled = true;
            else
                textBitcoin.enabled = false;
        }
        else
        {
            if (other.gameObject.name == "UsbKey")
            {
                GameObject go = other.GetComponents<GameObject>().ToList().Find(x => x == radio);
                /*
                 ArgumentException: GetComponent requires that the requested component 'GameObject' derives from MonoBehaviour or Component or is an interface.
                 UnityEngine.GameObject.GetComponents[GameObject] () (at C:/buildslave/unity/build/artifacts/generated/common/runtime/GameObjectBindings.gen.cs:101)
                 UnityEngine.Component.GetComponents[GameObject] () (at C:/buildslave/unity/build/artifacts/generated/common/runtime/ComponentBindings.gen.cs:185)
                 teleport.OnTriggerEnter (UnityEngine.Collider other) (at Assets/Scripts/teleport.cs:45)
                */
                if (go != null)
                    other = radio.GetComponent<Collider>();
            }
            if (other.gameObject.name == "PortalGenerator")
                return;
            other.transform.position = newRoom.transform.position;
            GameObject controllerL = GameObject.Find("Controller (left)");
            GameObject controllerR = GameObject.Find("Controller (right)");
            if (controllerL != null)
                controllerL.GetComponent<ControllerGrab>().drop();
            if (controllerR != null)
                controllerR.GetComponent<ControllerGrab>().drop();
        }
        mr.enabled = false;
        cc.enabled = false;
    }
}
