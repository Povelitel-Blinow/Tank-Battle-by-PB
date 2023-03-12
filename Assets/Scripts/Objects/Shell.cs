using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Shell : InteractableObject
{
    [SerializeField] private ShellType _shellType;
    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    public override void Interact(GameObject shellPos, GameObject cannon)
    {
        transform.position = shellPos.transform.position;
        transform.rotation = shellPos.transform.rotation;
        _boxCollider.enabled = false;
    }
}
