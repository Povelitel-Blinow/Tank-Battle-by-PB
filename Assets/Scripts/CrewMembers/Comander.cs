using UnityEngine;

[CreateAssetMenu]
public class Comander : CrewMemberRole
{
    [Header("LiftingSettings")]
    [SerializeField] private float _maxLifting;
    [SerializeField] private float _liftingSpeed;

    private float _currentLifting = 0f;
    public override void CrewWork(float state) 
    {
        Lift(state);
    }

    private void Lift(float state)
    {
        float lifting = state * _liftingSpeed * Time.deltaTime;
        if (_currentLifting + lifting < _maxLifting && _currentLifting + lifting > 0)
        {
            _seat.position += new Vector3(0, lifting, 0);
            _currentLifting += lifting;
        }
    }

    public override void StandUp()
    {
        _seat.position -= new Vector3(0, _currentLifting, 0);
        _currentLifting = 0f;
    }

    private void OnEnable()
    {
        _currentLifting = 0f;
    }

    private void OnDisable()
    {
        _currentLifting = 0f;
    }
}
