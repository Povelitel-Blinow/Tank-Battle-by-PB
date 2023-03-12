using UnityEngine;

[RequireComponent(typeof(PlayerLook))] 
[RequireComponent(typeof(PlayerInteract))] 
[RequireComponent(typeof(PlayerRole))] 
public class PlayerInput : MonoBehaviour
{
    private InputActions _inputActions;

    private InputActions.InTankActions _inTank;

    private PlayerLook _playerLook;
    private PlayerInteract _playerInteract;
    private PlayerRole _playerRole;

    private void Awake()
    {
        _inputActions = new InputActions();
        _inTank = _inputActions.InTank;
        _playerLook = GetComponent<PlayerLook>();
        _playerInteract = GetComponent<PlayerInteract>();
        _playerRole = GetComponent<PlayerRole>();
    }

    private void Update()
    {
        _playerLook.Look(_inTank.Look.ReadValue<Vector2>());

        if (_inTank.Interact.WasReleasedThisFrame())
            _playerInteract.InteractClick();

        _playerRole.CrewWork(_inTank.Aiming.ReadValue<Vector2>());

        _playerRole.CrewWork(_inTank.GetUp.ReadValue<Vector2>().y);

        if (Input.GetKey(KeyCode.Alpha1))
            _playerRole.ChangRole(0);
        else if (Input.GetKey(KeyCode.Alpha2))
            _playerRole.ChangRole(1);
        else if (Input.GetKey(KeyCode.Alpha3))
            _playerRole.ChangRole(2);
        else
            _playerRole.ChangRole(-1);
    }

    private void OnEnable()
    {
        _inTank.Enable();
    }

    private void OnDisable()
    {
        _inTank.Disable();
    }
}
