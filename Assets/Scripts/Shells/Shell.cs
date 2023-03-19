using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Shell : TakeableObject
{
    [SerializeField] private ShellType _shellType;
    [SerializeField] private GameObject _head;
    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    public override void Interact(Transform shellPos)
    {
        transform.position = shellPos.position;
        transform.rotation = shellPos.rotation;
        transform.parent = shellPos;

        gameObject.layer = TakenLayer;
        _head.layer = TakenLayer;

        _boxCollider.enabled = false;
    }
}
