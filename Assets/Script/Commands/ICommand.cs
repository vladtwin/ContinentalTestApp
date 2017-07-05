using UnityEngine;

public interface ICommand
{
    void Execute(GameObject context);
    bool CanExecute(GameObject context);
}