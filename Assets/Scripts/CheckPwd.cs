using UnityEngine;

public class CheckPwd : MonoBehaviour {

    private triggerColor.color[] pwd;
    private int indexPwd;
    private int nbAttempt;

    public Material screenOk, screenFail, screenOff, screenLog;
    public MeshRenderer screen;

    private bool isOn;
    
	void Start ()
    {
        isOn = true;
        init();
    }

    private void init()
    {
        nbAttempt = 1;
        pwd = new triggerColor.color[4];
    }

    public void switchOnOff()
    {
        isOn = !isOn;
        if (isOn)
        {
            screen.material = screenLog;
            init();
        }
        else
            screen.material = screenOff;
    }

    public void increasePwd(triggerColor.color key)
    {
        if (!isOn || indexPwd == 5) return;
        pwd[indexPwd] = key;
        if (indexPwd == 4)
        {
            if (pwd[0] == triggerColor.color.GREEN
                && pwd[1] == triggerColor.color.PINK
                && pwd[2] == triggerColor.color.BLUE
                && pwd[3] == triggerColor.color.RED)
                screen.material = screenOk;
            else if (nbAttempt < 3)
            {
                nbAttempt++;
                indexPwd = 0;
            }
            else
                screen.material = screenFail;
        }
        else
            indexPwd++;
    }
}
