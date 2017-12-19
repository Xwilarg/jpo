using UnityEngine;

public class triggerButton : MonoBehaviour {

    private const float trigger = -0.009f;

    public enum color
    {
        BLUE,
        GREEN,
        GREY,
        PINK,
        RED,
        YELLOW
    }

    public color myColor;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 newPos = transform.position;
        newPos.y += trigger;
        transform.position = newPos;
        transform.parent.GetComponent<CheckPwd>().increasePwd(myColor);
    }

    private void OnTriggerExit(Collider other)
    {
        Vector3 newPos = transform.position;
        newPos.y -= trigger;
        transform.position = newPos;
    }
}
