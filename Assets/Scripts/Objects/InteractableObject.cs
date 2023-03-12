using UnityEngine;

[RequireComponent(typeof(Outline))]
public class InteractableObject : MonoBehaviour
{
    [SerializeField] private float _outlineWidth = 3f;

    [Header("Action")]
    [SerializeField] protected PlayerActions _action;

    private Outline _outline;

    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
        gameObject.layer = 6;
        _outline.OutlineWidth = 0f;
    }

    public void OnSelection()
    {
        _outline.OutlineWidth = _outlineWidth;
    }

    public void OnSelectionExit()
    {
        _outline.OutlineWidth = 0f;
    }

    public virtual void Interact() { }
    public virtual void Interact(GameObject shellPos, GameObject cannon) { }
    public virtual void Interact(GameObject cam) { }
}
