using UnityEngine;

public class TakeableObject : SelectableObject
{
    protected const int SelectableLayer = 6;
    protected const int TakenLayer = 7;

    private void Start()
    {
        gameObject.layer = SelectableLayer;
    }
    
    public virtual void Take(Transform pos)
    {
        transform.position = pos.position;
        transform.rotation = pos.rotation;
        transform.parent = pos;

        gameObject.layer = TakenLayer;
    }
}
