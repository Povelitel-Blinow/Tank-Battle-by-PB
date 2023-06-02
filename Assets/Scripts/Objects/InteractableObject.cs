using UnityEngine;

public class InteractableObject : SelectableObject
{
    [Header("Action")]
    [SerializeField] protected PlayerActions _action;

    private const int InteractableObjectLayer = 6;

    private void Start()
    {
        gameObject.layer = InteractableObjectLayer;
    }

    public virtual void Interact(GameObject cam) { }
}
