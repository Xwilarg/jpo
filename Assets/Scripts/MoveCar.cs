using UnityEngine;

public class MoveCar : MonoBehaviour {

    private Rigidbody rb;
    public GameObject portails;

    public float speed;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        float horAxis = 0.0f;
        float verAxis = 0.0f;
        float speAxis = 0.0f;
        float upAxis = 0.0f;
        if (Input.GetKey(KeyCode.Z))
            verAxis += 1f;
        else if (Input.GetKey(KeyCode.S))
            verAxis += -1f;
        if (Input.GetKey(KeyCode.Q))
            horAxis += -1f;
        else if (Input.GetKey(KeyCode.D))
            horAxis += 1f;
        if (Input.GetKey(KeyCode.Keypad4))
            speAxis += -1f;
        else if (Input.GetKey(KeyCode.Keypad6))
            speAxis += 1f;
        if (Input.GetKey(KeyCode.Space))
            upAxis += 1f;
        if (Input.GetKey(KeyCode.E))
            portails.SetActive(true);
        transform.Translate(Vector3.forward * speed * verAxis);
        // rb.velocity = new Vector3(0.0f, 0.0f, Mathf.Lerp(0, verAxis * speed, 0.8f));
        transform.Rotate(new Vector3(0.0f, Mathf.Lerp(0, horAxis * speed * 100f, 0.8f), Mathf.Lerp(0, speAxis * speed * 300f, 0.8f)));
        rb.AddForce(new Vector3(0.0f, upAxis * speed * 10f, 0.0f), ForceMode.Impulse);
    }
}
