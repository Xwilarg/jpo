using UnityEngine;

public class triggerColor : MonoBehaviour {

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
        transform.parent.GetComponent<CheckPwd>().increasePwd(myColor);
        transform.parent.GetComponent<CheckPwd>().changeVolume(myColor);
        transform.parent.GetComponent<CheckPwd>().changeVideo(myColor);
    }
}
