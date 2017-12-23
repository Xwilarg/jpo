﻿using UnityEngine;

public class triggerButton : MonoBehaviour {

    private const float trigger = -0.009f;

    private BoxCollider bc;

    public void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 newPos = transform.position;
        newPos.y += trigger;
        transform.position = newPos;
        bc.size = new Vector3(1f, 5f, 1f);
    }

    private void OnTriggerExit(Collider other)
    {
        Vector3 newPos = transform.position;
        newPos.y -= trigger;
        transform.position = newPos;
        bc.size = new Vector3(1f, 1f, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnTriggerEnter(collision.collider);
    }

    private void OnCollisionExit(Collision collision)
    {
        OnTriggerExit(collision.collider);
    }
}
