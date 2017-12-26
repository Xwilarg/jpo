using UnityEngine;

public class MoveCar : MonoBehaviour {

    private Rigidbody rb;
    public bool isEnable { set; private get; }

    public float speed;

	void Start () {
        rb = GetComponent<Rigidbody>();
        isEnable = false;
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Engine Start/Stop") && transform.parent.name != "Controller (right)" && transform.parent.name != "Controller (left)")
        {
            isEnable = !isEnable;
            if (isEnable)
            {
                rb.useGravity = false;
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, transform.rotation.eulerAngles.y, 0.0f));
            }
            else
                rb.useGravity = true;
        }
        if (isEnable)
        {
            int forAxis = 0;
            int verAxis = 0;
            int horAxis = 0;
            if (Input.GetButton("Forward"))
                forAxis = 1;
            else if (Input.GetButton("Backward"))
                forAxis = -1;
            if (Input.GetButton("Up"))
                verAxis = 1;
            else if (Input.GetButton("Down"))
                verAxis = -1;
            if (Input.GetButton("Right"))
                horAxis = 1;
            else if (Input.GetButton("Left"))
                horAxis = -1;
            rb.velocity = new Vector3(Mathf.Lerp(0, forAxis * speed, 0.8f), Mathf.Lerp(0, verAxis * speed, 0.8f), Mathf.Lerp(0, -horAxis * speed, 0.8f));
            transform.Rotate(new Vector3(0.0f, Input.GetAxis("Mouse X"), 0.0f));
        }
    }
}
