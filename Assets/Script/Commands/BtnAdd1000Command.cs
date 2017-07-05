using System;
using Assets;
using UnityEngine;

internal class BtnAdd1000Command : CommandBase
{
    private CharacterViewController characterViewController;

    public BtnAdd1000Command(UIMenuBase aPanel) : base(aPanel)
    {
    }

    public override void Execute(GameObject context)
    {
        try
        {
            if (!CanExecute(context))
                return;
            PlayerSingleton.Singleton.Player.Money += 1000;
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}