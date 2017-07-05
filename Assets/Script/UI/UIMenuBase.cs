
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIMenuBase :  UIMenu
{
    public GameObject Instance;
    protected Dictionary<GameObject, ICommand> associations = new Dictionary<GameObject, ICommand>();
    protected List<GameObject> activeButtons;

   
    public abstract void Init();
    public GameObject GetGoInstance()
    {
        return Instance;
    }
    public virtual void Show()
    {
    }
    public virtual void Hide()
    {
    }
    public virtual bool CanShow(GameObject guiItem)
    {
        return true;
    }
    public virtual bool IsShown(GameObject guiItem)
    {
        return true;
    }
    public virtual bool IsAvalibale(GameObject guiItem)
    {
        return true;
    }
    public virtual bool CanButtonClick(GameObject button)
    {
        if (!associations.ContainsKey(button))
            return false;

        return associations[button].CanExecute(button);
    }
    public virtual void ButtonClick(GameObject button)
    {
        if (!associations.ContainsKey(button))
            return;

        if (associations[button].CanExecute(button))
            associations[button].Execute(button);
    }
    
     public void associateButton(GameObject guiItem, ICommand command)
    {
        associate(guiItem, command);
        guiItem.GetComponent<Button>().onClick.AddListener(delegate { command.Execute(guiItem); });
    }
     public void associate(GameObject guiItem, ICommand command)
    {
        associations.Add(guiItem, command);
    }
    public void removeAssociation(GameObject guiItem)
    {
        if (associations.ContainsKey(guiItem))
            associations.Remove(guiItem);
    }
}