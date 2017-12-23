using System.Collections.Generic;
using UnityEngine;

public class TaserCloser : MonoBehaviour {
    
    private LineRenderer lr;
    private List<GameObject> attracting;
    private const float speed = 0.5f;

    private void Start()
    {
        attracting = new List<GameObject>();
        lr = GetComponent<LineRenderer>();
    }

    public void stop()
    {
        foreach (GameObject g in attracting)
        {
            if (g != null)
            {
                Rigidbody rb = g.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.useGravity = true;
                    rb.isKinematic = false;
                }
            }
        }
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 posIni = transform.position - transform.right / 10;
        if (Physics.Raycast(posIni, -transform.right, out hit))
        {
            lr.SetPosition(0, posIni);
            lr.SetPosition(1, hit.point);
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("Grappable"))
            {
                attracting.Add(go);
                Rigidbody rb = go.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.useGravity = false;
                    rb.isKinematic = true;
                }
            }
        }
        foreach (GameObject g in attracting)
        {
            if (g != null)
            {
                Vector3 objPos = g.transform.position;
                if (objPos.x < transform.position.x)
                    objPos.x += speed * Time.deltaTime;
                else
                    objPos.x -= speed * Time.deltaTime;
                if (objPos.y < transform.position.y)
                    objPos.y += speed * Time.deltaTime;
                else
                    objPos.y -= speed * Time.deltaTime;
                g.transform.position = objPos;
            }
        }
    }
}
