using UnityEngine;

public class PlayerRole : MonoBehaviour
{
    [SerializeField] private CrewMemberRole[] _role;
    [SerializeField] private Transform[] _seat;
    [SerializeField] private GameObject _tank;
    [SerializeField] private int _currentRole = 0;

    private void Start()
    {
        if (_currentRole >= _role.Length)
            _currentRole = 0;
        ChangRole(_currentRole);
    }

    public void ChangRole(int newRole)
    {
        if (newRole < _role.Length)
        {
            _currentRole = newRole;
            _role[_currentRole].TakeASeat(gameObject, _seat[_currentRole], _tank.GetComponent<Tank>());
        }
    }

    public void CrewWork(float state) { _role[_currentRole].CrewWork(state); }
    public void CrewWork(Vector2 rotation) { _role[_currentRole].CrewWork(rotation); }
}
