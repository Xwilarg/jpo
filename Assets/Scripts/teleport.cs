﻿using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject newRoom;
    private MeshRenderer mr;
    private CapsuleCollider cc;
    public MeshRenderer textBitcoin;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        cc = GetComponent<CapsuleCollider>();
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
        GameObject radio = GameObject.Find("Radio");
        if (other.gameObject.name == "UsbKey")
        {
            GameObject[] Incollision = other.GetComponents<GameObject>();
            foreach (GameObject c in Incollision)
            {
                if (c == radio)
                    other = radio.GetComponent<Collider>();
            }
        }
        if (newRoom != null && (other.name == "Camera (eye)" || other.name == "Controller (left)" || other.name == "Controller (right)"))
        {
            GameObject.Find("[CameraRig]").transform.position = newRoom.transform.position;
            if (newRoom.name == "Blockchain")
                textBitcoin.enabled = true;
            else
                textBitcoin.enabled = false;
        }
        else
        {
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
