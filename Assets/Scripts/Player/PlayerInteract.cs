using UnityEngine;

[RequireComponent(typeof(PlayerLook))]
[RequireComponent(typeof(PlayerTake))]
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _distance;
    private PlayerLook _playerLook;
    private Camera _cam;
    private Ray _ray;

    private InteractableObject _currentInteractactedObject;

    private CameraBehaviour _cameraBehaviour;

    private PlayerTake _playerTake;

    private bool _isInteracting = false;
    
    private void Start()
    {
        _playerLook = GetComponent<PlayerLook>();
        _playerTake = GetComponent<PlayerTake>();
        _cam = _playerLook.GetCam();
        _cameraBehaviour = _cam.GetComponent<CameraBehaviour>();
    }

    private void FixedUpdate()
    {
        _ray = new Ray(_cam.transform.position, _cam.transform.forward);
    }

    private void Update()
    {
        if (!_isInteracting)
        {
            RaycastHit hitinfo;
            if (Physics.Raycast(_ray, out hitinfo, _distance, _mask))
            {
                hitinfo.collider.TryGetComponent(out InteractableObject obj);
                if (_currentInteractactedObject != obj)
                {
                    _currentInteractactedObject?.OnSelectionExit();
                    _currentInteractactedObject = obj;
                    _currentInteractactedObject?.OnSelection();
                }

                if(hitinfo.collider.TryGetComponent(out Cannon cannon))
                {
                    TakeableObject tmp = _playerTake.LayDown();
                    if (!cannon.Interact(tmp))
                    {
                        _playerTake.TakeObject(tmp);
                        cannon.OnSelectionExit();
                        Debug.Log(1);
                    }
                }
            }
            else
            {
                _currentInteractactedObject?.OnSelectionExit();
                _currentInteractactedObject = null;
            }
        }
        else
            _currentInteractactedObject?.Interact(_cam.gameObject);
    }

    public void Click()
    {

        if (!_isInteracting)
        {
            TryInteract();
            TryTake();
            _currentInteractactedObject?.OnSelectionExit();
        }
        else
        {
            _cameraBehaviour.CamViewPortExit();
        }
        _isInteracting = !_isInteracting;
    }

    private void TryInteract()
    {
        _currentInteractactedObject?.Interact();
        _currentInteractactedObject?.Interact(_cam.gameObject);
    }

    private void TryTake()
    {
        if (!_playerTake.GetIsCarrying())
        {
            _playerTake?.TakeObject(_currentInteractactedObject?.GetComponent<TakeableObject>());
        }
    }

    public bool GetIsInteracting()
    {
        return _isInteracting;
    }
}
