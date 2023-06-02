using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Shell : Ammo
{
    [SerializeField] private ShellType _shellType;
    [SerializeField] private ShellHead _head;
    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    public override void Take(Transform pos)
    {
        base.Take(pos);
        _head.gameObject.layer = TakenLayer;

        _boxCollider.enabled = false;
    }

    public override void Loaded()
    {
        _head.gameObject.layer = 0;
        gameObject.layer = 0;
    }

    public override void Shoot()
    {
        _head.transform.parent = null;
        _head.Shoot(_shellType.GetForce());
        Destroy(gameObject);
    }
}
