using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Cannon : SelectableObject, ILoadable
{
    [SerializeField] private GameObject _loadPos;
    private Ammo _currentShell;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Load(Ammo ammo)
    {
        if (_currentShell == null)
        {
            ammo.gameObject.transform.position = _loadPos.transform.position;
            ammo.gameObject.transform.rotation = _loadPos.transform.rotation;
            ammo.gameObject.transform.parent = _loadPos.transform;

            _animator.SetTrigger("Load");
            _currentShell = ammo;
            ammo.Loaded();
        }
    }

    public void Shoot()
    {
        if(_currentShell != null)
        {
            _animator.SetTrigger("Shoot");
            _currentShell.Shoot();
            _currentShell = null;
        }
    }
}
