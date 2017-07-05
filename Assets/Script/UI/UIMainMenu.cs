using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : UIMenuBase
{
    
    public GameObject BtnAdd100;
    public GameObject BtnAdd1000;
    public GameObject BtnExit;

    public UIMainMenu(GameObject btnAdd100, GameObject btnAdd1000, GameObject btnExit)
    {
        BtnAdd100 = btnAdd100;
        BtnAdd1000 = btnAdd1000;
        BtnExit = btnExit;
    }

    public override void Init()
    {
        associateButton(BtnAdd100, new BtnAdd100Command(this));
        associateButton(BtnAdd1000, new BtnAdd1000Command(this));
        associateButton(BtnExit, new BtnExitCommand(this));
    }
}

