using UnityEngine;

public class Taser : MonoBehaviour {

    public bool makeBigger;
    private LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

	void Update ()
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
                if (makeBigger)
                    go.transform.localScale *= 1.01f;
                else
                    go.transform.localScale *= 0.99f;
            }
        }
    }
}
