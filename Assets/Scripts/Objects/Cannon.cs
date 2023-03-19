using UnityEngine;

public class Cannon : InteractableObject
{
    private TakeableObject _currentShell;

    public override bool Interact(TakeableObject shell)
    {
        if(_currentShell == null && shell != null)
        {
            _currentShell = shell;

            Destroy(shell.gameObject);

            return true;
        }
        return false;
    }
}
