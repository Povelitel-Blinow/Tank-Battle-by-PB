using UnityEngine;

public class PlayerTake : MonoBehaviour
{
    [SerializeField] private Transform _takePos;

    private TakeableObject _currentTakenObject;
    private bool _isCarrying;

    public void TakeObject(TakeableObject takeableObject) 
    {
        if (_currentTakenObject == null && takeableObject != null)
        {
            _currentTakenObject = takeableObject;
            _currentTakenObject.Interact(_takePos);
            _isCarrying = true;
        }
    }

    public TakeableObject LayDown()
    {
        TakeableObject tmp = _currentTakenObject;
        _currentTakenObject = null;
        _isCarrying = false;
        return tmp;
    }

    public bool GetIsCarrying()
    {
        return _isCarrying;
    }
}
