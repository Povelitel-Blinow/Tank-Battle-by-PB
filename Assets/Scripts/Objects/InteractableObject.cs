using UnityEngine;

public class InteractableObject : SelectableObject
{
    [Header("Action")]
    [SerializeField] protected PlayerActions _action;

    private void Start()
    {
        gameObject.layer = InteractableObjectLayer;
    }

    private const int InteractableObjectLayer = 6;

    public virtual void Interact() { }
    public virtual void Interact(GameObject shellPos, GameObject cannon) { }
    public virtual void Interact(GameObject cam) { }
    public virtual void Interact(Transform pos) { }
    public virtual bool Interact(TakeableObject shell) { return false; }
}
