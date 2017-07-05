using UnityEngine;

public class TryImproveCharacterCommand : CommandBase
{
    UICharacter UiCharacter;
    public TryImproveCharacterCommand(UIMenuBase aPanel) : base(aPanel)
    {
        UiCharacter=aPanel as UICharacter;
    }

    public override void Execute(GameObject button)
    {
        if (base.CanExecute(button)&&UiCharacter!=null)
        {
          //  UiCharacter.ConfirmUI.SetActive(true);
        }
    }
}