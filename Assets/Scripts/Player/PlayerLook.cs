using UnityEngine;

public class PlayerLook : Player
{
    [SerializeField] private Camera _cam;

    [Header("Settings")]
    [SerializeField] private float _maxRotUp = 30f;
    [SerializeField] private float _maxRotDown = -30f;

    [SerializeField] private float _xSens = 1f;
    [SerializeField] private float _ySens = 1f;


    private float xRot;

    private CameraBehaviour _cameraBehaviour;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _cameraBehaviour = _cam.GetComponent<CameraBehaviour>();
    }

    public void Look(Vector2 input)
    {
        if (!_cameraBehaviour.GetIsFrozen())
        {
            float mouseX = input.x/5;
            float mouseY = input.y/5;

            xRot -= (mouseY * Time.deltaTime) * _ySens;
            xRot = Mathf.Clamp(xRot, _maxRotDown, _maxRotUp);

            _cam.transform.localRotation = Quaternion.Euler(xRot, 0, 0);

            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xSens);
        }
    }

    public Camera GetCam()
    {
        return _cam;
    }
}
