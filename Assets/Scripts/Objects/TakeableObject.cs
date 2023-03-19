using UnityEngine;

[RequireComponent(typeof(SelectableObject))]
public class TakeableObject : InteractableObject
{
    protected const int SelectableLayer = 6;
    protected const int TakenLayer = 7;

    private void Start()
    {
        gameObject.layer = SelectableLayer;
    }

    public override void Interact(Transform pos) { }
}
