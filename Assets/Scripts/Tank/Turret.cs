using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject _horisontalRotationHandle;
    [SerializeField] private GameObject _verticalRotationHandle;
    [SerializeField] private GameObject _cannon;
    [SerializeField] private GameObject _aimerViewPort;

    [SerializeField] private float _handleRotSpeed;
    [SerializeField] private float _turretRotSpeed;
    [SerializeField] private float _cannonRotSpeed;

    [SerializeField] private float _cannonRotUp;
    [SerializeField] private float _cannonRotDown;

    private void Start()
    {
        _cannonRotUp += 360f;
    }

    public void TurretAim(Vector2 rotation)
    {
        float x = rotation.x;
        float y = rotation.y;

        transform.rotation *= Quaternion.Euler(0, 0, x * Time.deltaTime * _turretRotSpeed);

        Quaternion newCannonRot = _cannon.transform.localRotation * Quaternion.Euler(y * Time.deltaTime * -_cannonRotSpeed, 0, 0);
        if (newCannonRot.eulerAngles.x > _cannonRotUp || newCannonRot.eulerAngles.x < _cannonRotDown)
        {
            _cannon.transform.rotation *= Quaternion.Euler(y * Time.deltaTime * -_cannonRotSpeed, 0, 0);
            _verticalRotationHandle.transform.rotation *= Quaternion.Euler(y * Time.deltaTime * _handleRotSpeed, 0, 0);
            _aimerViewPort.transform.rotation *= Quaternion.Euler(y * Time.deltaTime * -_cannonRotSpeed, 0, 0);
        }

        _horisontalRotationHandle.transform.rotation *= Quaternion.Euler(0, 0, x*Time.deltaTime*_handleRotSpeed);
        
    }
}
