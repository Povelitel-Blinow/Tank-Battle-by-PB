using UnityEngine;

[RequireComponent(typeof(Outline))]
public class SelectableObject : MonoBehaviour
{
    [SerializeField] private float _outlineWidth = 3f;

    private Outline _outline;

    private void OnEnable()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
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
}
