using UnityEngine;

public class ShellType : ScriptableObject
{
    [SerializeField] private string _name;

    public virtual void OnCollision() { }
}
