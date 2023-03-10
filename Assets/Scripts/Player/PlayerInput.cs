using UnityEngine;

[RequireComponent(typeof(PlayerLook))] 
[RequireComponent(typeof(PlayerInteract))] 
[RequireComponent(typeof(PlayerRole))] 
public class PlayerInput : MonoBehaviour
{
    private InputActions _inputActions;

    private InputActions.InTankActions _inTank;

    private PlayerLook _crewMemberLook;
    private PlayerInteract _playerInteract;
    private PlayerRole _playerRole;

    private void Awake()
    {
        _inputActions = new InputActions();
        _inTank = _inputActions.InTank;
        _crewMemberLook = GetComponent<PlayerLook>();
        _playerInteract = GetComponent<PlayerInteract>();
        _playerRole = GetComponent<PlayerRole>();
    }

    private void Update()
    {
        _crewMemberLook.Look(_inTank.Look.ReadValue<Vector2>());

        if (_inTank.Interact.WasReleasedThisFrame())
            _playerInteract.InteractClick();

        _playerRole.CrewWork(_inTank.Aiming.ReadValue<Vector2>());

        _playerRole.CrewWork(_inTank.GetUp.ReadValue<Vector2>().y);

        if (Input.GetKeyDown(KeyCode.Alpha1))
            _playerRole.ChangRole(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _playerRole.ChangRole(1);
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
