using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Shell : Ammo
{
    [SerializeField] private GameObject _head;
    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    public override void Take(Transform pos)
    {
        base.Take(pos);
        _head.layer = TakenLayer;

        _boxCollider.enabled = false;
    }
}
