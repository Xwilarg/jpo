using UnityEngine;

public class ButtonDisparition : MonoBehaviour {
    public float speed;
    private bool doesGoDown;
    private Vector3 iniPos;

    private void Start()
    {
        doesGoDown = false;
        iniPos = transform.position;
    }

    private void Update()
    {
        if (doesGoDown)
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
    }

    public void goDown()
    {
        doesGoDown = true;
    }

    public void resetPos()
    {
        transform.position = iniPos;
    }
}
