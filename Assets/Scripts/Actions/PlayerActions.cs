using UnityEngine;

public class PlayerActions : ScriptableObject
{
    public virtual void DoIt() { }
    public virtual void DoIt(Camera cam) { }
    public virtual void DoIt(Camera cam, GameObject obj) { }
    public virtual void DoIt(GameObject cam, GameObject obj) { }
}
