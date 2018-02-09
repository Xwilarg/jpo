﻿using UnityEngine;
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
            GameObject toTp = other.gameObject;
            while (toTp.transform.parent.GetComponent<valueObject>() != null || toTp.transform.parent.name == "RadioInput")
            {
                toTp = toTp.transform.parent.gameObject;
            }
            toTp.transform.position = newRoom.transform.position;
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
