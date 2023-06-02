using UnityEngine;

[RequireComponent(typeof(PlayerInteract))]
[RequireComponent(typeof(ChangeRoleUI))]
public class PlayerRole : Player
{
    [SerializeField] private CrewMemberRole[] _role;
    [SerializeField] private Transform[] _seat;
    [SerializeField] private Tank _tank;
    [SerializeField] private int _currentRole = 0;
    [SerializeField] private float _changeRoleTime;

    private ChangeRoleUI _changeRoleUI;
    private PlayerInteract _playerInteract;
    private float _timer = 0f;
    private int _nextRole;

    private const int _nullChangeRoleValue = -1;

    private void Start()
    {
        _playerInteract = GetComponent<PlayerInteract>();
        _changeRoleUI = GetComponent<ChangeRoleUI>();

        if (_currentRole >= _role.Length)
            _currentRole = 0;
        TakeASeat();
    }

    public void ChangRole(int newRole)
    {   if (newRole != _nullChangeRoleValue && newRole != _currentRole && !_playerInteract.GetIsInteracting())
        {
            _timer += Time.deltaTime;
            _changeRoleUI.SetTimer(_changeRoleTime - _timer);

            if (newRole < _role.Length && _timer >= _changeRoleTime)
            {
                StandUp();

                _timer = 0f;
                _changeRoleUI.EndTimer();
                _currentRole = newRole;
                
                TakeASeat();
            }
            if (_nextRole != newRole)
            {
                _changeRoleUI.StartTimer();
                _timer = 0;
            }
            _nextRole = newRole;
        }
        else
        {
            _timer = 0;
            _nextRole = _nullChangeRoleValue;
            _changeRoleUI.EndTimer();
        }
    }

    private void TakeASeat()
    {
        _role[_currentRole].TakeASeat(gameObject, _seat[_currentRole], _tank);
    }

    private void StandUp()
    {
        _role[_currentRole].StandUp();
    }

    public void CrewWork(float comanderGeuUp) 
    { 
        if(!_playerInteract.GetIsInteracting())
            _role[_currentRole].CrewWork(comanderGeuUp); 
    }

    public void CrewWork(Vector2 rotation) { _role[_currentRole].CrewWork(rotation); }
}
