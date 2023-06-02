using UnityEngine;
public class Cannon : SelectableObject, ILoadable
{
    private CannonAmmo _currentShell;

    public void Load(Ammo ammo)
    {
        Debug.Log("Shell");
        ammo.Loaded();
    }
}
