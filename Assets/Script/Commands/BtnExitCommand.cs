using System;
using Assets;
using UnityEngine;

public class BtnExitCommand : CommandBase
{
    public BtnExitCommand(UIMenuBase aPanel)
       : base(aPanel) { }

    public override void Execute(GameObject context)
    {
        Application.Quit();
    }

}