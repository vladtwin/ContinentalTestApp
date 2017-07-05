using System;
using Assets;
using UnityEngine;

public class BtnAdd100Command : CommandBase
{
    public BtnAdd100Command(UIMenuBase aPanel)
       : base(aPanel) { }

    public override void Execute(GameObject context)
    {
        try
        {
            if (!CanExecute(context))
                return;
            PlayerSingleton.Singleton.Player.Money += 100;
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

}