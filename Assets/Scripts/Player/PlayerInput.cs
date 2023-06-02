using UnityEngine;

[RequireComponent(typeof(PlayerLook))] 
[RequireComponent(typeof(PlayerInteract))] 
[RequireComponent(typeof(PlayerRole))] 
public class PlayerInput : Player
{
    private InputActions _inputActions;

    private InputActions.InTankActions _inTank;

    private PlayerLook _playerLook;
    private PlayerInteract _playerInteract;
    private PlayerRole _playerRole;

    public delegate void OnLook(Vector2 look);
    public event OnLook onLook;

    public delegate void OnInteract();
    public event OnInteract onInteract;

    public delegate void OnChangeRole(int role);
    public event OnChangeRole onChangeRole;

    private int _crewRole = -1;

    private void Awake()
    {

        Application.targetFrameRate = 60;
        _inputActions = new InputActions();
        _inTank = _inputActions.InTank;

        _playerLook = GetComponent<PlayerLook>();
        onLook += _playerLook.Look;

        _playerInteract = GetComponent<PlayerInteract>();
        onInteract += _playerInteract.Click;

        _playerRole = GetComponent<PlayerRole>();
        onChangeRole += _playerRole.ChangRole;
    }

    private void Update()
    {
        onLook(_inTank.Look.ReadValue<Vector2>());

        if (_inTank.Interact.WasReleasedThisFrame())
            onInteract();

        _crewRole = CheckCrewRole();
        onChangeRole(_crewRole);

        _playerRole.CrewWork(_inTank.Aiming.ReadValue<Vector2>());
        _playerRole.CrewWork(_inTank.CommanderGetUp.ReadValue<Vector2>().y);   
    }

    private int CheckCrewRole()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            return 0;
        else if (Input.GetKey(KeyCode.Alpha2))
            return 1;
        else if (Input.GetKey(KeyCode.Alpha3))
            return 2;
        else
            return -1;
    }

    private void OnEnable()
    {
        _inTank.Enable();
    }

    private void OnDisable()
    {
        onLook -= _playerLook.Look;
        onInteract -= _playerInteract.Click;
        onChangeRole -= _playerRole.ChangRole;

        _inTank.Disable();
    }
}
