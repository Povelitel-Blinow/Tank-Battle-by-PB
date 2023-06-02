using UnityEngine;

[RequireComponent(typeof(PlayerLook))]
public class PlayerInteract : Player
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _takePos;

    private PlayerLook _playerLook;
    private Camera _cam;
    private Ray _ray;

    private SelectableObject _currentSelectedObject;
    private InteractableObject _currentInteractedObject;

    private CameraBehaviour _cameraBehaviour;

    private TakeableObject _currentTakenObject;
    private bool _isCarrying;

    private bool _isInteracting = false;
    
    private void Start()
    {
        _playerLook = GetComponent<PlayerLook>();
        _cam = _playerLook.GetCam();
        _cameraBehaviour = _cam.GetComponent<CameraBehaviour>();
    }

    private void FixedUpdate()
    {
        _ray = new Ray(_cam.transform.position, _cam.transform.forward);
    }

    private void Update()
    {

        if (_isInteracting == false)
        {
            RaycastHit hitinfo;
            if (Physics.Raycast(_ray, out hitinfo, _distance, _mask))
            {
                hitinfo.collider.TryGetComponent(out SelectableObject obj);
                if (_currentSelectedObject != obj)
                {
                    _currentSelectedObject?.OnSelectionExit();
                    _currentSelectedObject = obj;
                    _currentSelectedObject?.OnSelection();
                }
            }
            else
            {
                _currentSelectedObject?.OnSelectionExit();
                _currentSelectedObject = null;
            }
        }
        else
        {
            _currentInteractedObject.Interact(_cameraBehaviour);
        }
    }

    public void Click()
    {
        if (_isInteracting == false)
        {
            if (_currentSelectedObject != null)
            {
                TryTake();
                TryInteract();
                TryLoad();
                _currentSelectedObject?.OnSelectionExit();
            }
        }
        else
        {
            if (_currentInteractedObject.GetComponent<ViewPort>() != null)
                _cameraBehaviour.CamViewPortExit();
            _isInteracting = false;
        }
    }

    private void TryInteract()
    {
        if (_isInteracting == false)
        {
            _currentSelectedObject.TryGetComponent(out _currentInteractedObject);
            if (_currentInteractedObject != null)
            {
                _currentInteractedObject.Interact(_cameraBehaviour);
                _isInteracting = true;
            }
        }
    }

    private void TryTake()
    {
        if(_isCarrying == false)
        {
            _currentSelectedObject.TryGetComponent(out _currentTakenObject);
            if (_currentTakenObject != null)
            {
                _currentTakenObject.Take(_takePos);
                _isCarrying = true;
            }
        }
    }

    private void TryLoad()
    {
        ILoadable loadable = _currentSelectedObject.GetComponent<ILoadable>();
        if (loadable != null && _currentTakenObject != null)
        {
            Ammo ammo = _currentTakenObject.GetComponent<Ammo>();
            if (ammo != null)
            {
                loadable.Load(ammo);
                _isCarrying = false;
            }
        }
    }

    public void TryShoot()
    {
        if (_currentInteractedObject != null)
        {
            _currentInteractedObject.TryGetComponent(out IShootable shootable);
            if (shootable != null)
            {
                shootable.Shoot();
            }
        }
    }

    public bool GetIsInteracting()
    {
        return _isInteracting;
    }
}
