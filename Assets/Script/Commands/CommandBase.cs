using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandBase : ICommand {
    protected UIMenuBase panel;
    public CommandBase(UIMenuBase aPanel) {
        panel = aPanel;
    }
    public virtual bool CanExecute(GameObject button) {
        return true;
    }
    public virtual void Execute(GameObject button) {
    }               
}
