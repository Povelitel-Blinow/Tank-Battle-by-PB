using UnityEngine;

[RequireComponent(typeof(PlayerLook))]
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _distance;
    private PlayerLook _playerLook;
    private Camera _cam;
    private Ray _ray;
    private InteractableObject _currentSelectedObj;
    private CameraBehaviour _cameraBehaviour;

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
        if (!_isInteracting)
        {
            RaycastHit hitinfo;
            if (Physics.Raycast(_ray, out hitinfo, _distance, _mask))
            {
                InteractableObject obj = hitinfo.collider.gameObject?.GetComponent<InteractableObject>();
                if (_currentSelectedObj != obj)
                {
                    _currentSelectedObj?.OnSelectionExit();
                    _currentSelectedObj = obj;
                    _currentSelectedObj?.OnSelection();
                }
            }
            else
            {
                _currentSelectedObj?.OnSelectionExit();
                _currentSelectedObj = null;
            }
        }
        else
        {
            
            _currentSelectedObj?.Act(_cam);
        }
    }

    public void InteractClick()
    {
        if (!_isInteracting)
        {
            _currentSelectedObj?.Act();
            _currentSelectedObj?.Act(_cam);
            _currentSelectedObj?.OnSelectionExit();
        }
        else
            _cameraBehaviour.CamInViewPortExit();

        _isInteracting = !_isInteracting;
    }

}
