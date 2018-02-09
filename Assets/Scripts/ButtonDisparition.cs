using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDisparition : MonoBehaviour {
    public float speed;
    private Transform dest;
    private Vector3 velocity;
    private Vector3 position;

	// Use this for initialization
	void Start () {
        velocity = Vector3.zero;
        transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        position = dest.TransformPoint(new Vector3(0, 5, -10));
        transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, speed);
	}
}
