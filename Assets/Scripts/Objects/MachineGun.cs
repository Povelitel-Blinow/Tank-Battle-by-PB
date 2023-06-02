using UnityEngine;

public class MachineGun : InteractableObject, IShootable
{
    [Header("Shoot Settings")]
    [SerializeField] private Transform _muzzle;
    [SerializeField] private int _magCapasity;
    [SerializeField] private int _currentBullets;
    [SerializeField] private float _fireRate;
    [SerializeField] private GameObject _effect;

    [SerializeField] private GameObject _stand;
    [SerializeField] private float _maxHorizontalRotation;

    private float _timer = 0f;

    private void Update()
    {
        if(_timer < _fireRate)
            _timer += Time.timeScale;
    }

    public override void Interact(CameraBehaviour cam)
    {
        transform.localRotation = Quaternion.Euler(cam.transform.localRotation.eulerAngles.x, 0, 0);
        float yRot = cam.transform.parent.localRotation.eulerAngles.y;
        if (yRot < _maxHorizontalRotation || yRot > 360-_maxHorizontalRotation)
            _stand.transform.localRotation = Quaternion.Euler(0, 0, yRot);
    }

    public void Shoot()
    {
        if(_timer >= _fireRate)
        {
            Debug.Log(11);
            Instantiate(_effect, _muzzle.transform);
            _timer = 0f;
        }
    }
}
