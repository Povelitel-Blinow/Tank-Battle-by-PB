using UnityEngine;

[RequireComponent(typeof(CameraUI))]
public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _defaultCamPos;

    private bool _isFrozen = false;
    private CameraUI _cameraUI;

    private void Start()
    {
        _cameraUI = GetComponent<CameraUI>();
    }

    public bool GetIsFrozen()
    {
        return _isFrozen;
    }

    public void CamInViewPort(GameObject viewPort)
    {
        ChangeCamPos(viewPort);
        _cameraUI.InViewPort();
        _isFrozen = true;
    }

    public void CamInAimViewPort(GameObject viewPort)
    {
        ChangeCamPos(viewPort);
        _cameraUI.InAimViewPort();
        _isFrozen = true;
    }

    public void CamViewPortExit()
    {
        ChangeCamPos(_defaultCamPos);
        _cameraUI.NotInViewPort();
        _isFrozen = false;
        transform.parent = _defaultCamPos.transform.parent;
    }

    private void ChangeCamPos(GameObject newPos)
    {
        
        transform.position = newPos.transform.position;
        transform.rotation = newPos.transform.rotation;
        transform.parent = newPos.transform;
    }
}
