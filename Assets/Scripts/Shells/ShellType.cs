using UnityEngine;

public class ShellType : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _force;

    public float GetForce()
    {
        return _force;
    }
}
