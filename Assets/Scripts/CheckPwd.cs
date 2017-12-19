using UnityEngine;

public class CheckPwd : MonoBehaviour {

    private triggerButton.color[] pwd;
    private int indexPwd;
    private int nbAttempt;

    public Material screenOk, screenFail;
    public MeshRenderer screen;
    
	void Start ()
    {
        nbAttempt = 1;
        pwd = new triggerButton.color[4];
	}

    public void increasePwd(triggerButton.color key)
    {
        if (indexPwd == 5) return;
        pwd[indexPwd] = key;
        if (indexPwd == 4)
        {
            if (pwd[0] == triggerButton.color.GREEN
                && pwd[1] == triggerButton.color.PINK
                && pwd[2] == triggerButton.color.BLUE
                && pwd[3] == triggerButton.color.RED)
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
