﻿using System.Collections.Generic;
using UnityEngine;

public class CheckPwd : MonoBehaviour {

    private List<triggerColor.color> pwd;
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
        pwd = new List<triggerColor.color>();
        nbAttempt = 1;
        indexPwd = 1;
    }

    public void switchOnOff(bool value)
    {
        isOn = value;
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
        pwd.Add(key);
        if (indexPwd == 4)
        {
            Debug.Log("AAA");
            if (pwd[0] == triggerColor.color.GREEN
                && pwd[1] == triggerColor.color.PINK
                && pwd[2] == triggerColor.color.BLUE
                && pwd[3] == triggerColor.color.RED)
                screen.material = screenOk;
            else if (nbAttempt < 3)
            {
                nbAttempt++;
                indexPwd = 1;
                pwd = new List<triggerColor.color>();
            }
            else
                screen.material = screenFail;
        }
        else
            indexPwd++;
    }
}
