using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _defaultCamPos;
    private bool _isFrozen = false;

    public bool GetIsFrozen()
    {
        return _isFrozen;
    }

    public void CamInViewPort(GameObject newParent)
    {
        ChangeParent(newParent);
        _isFrozen = true;
    }

    public void CamInViewPortExit(GameObject newParent)
    {
        ChangeParent(newParent);
        _isFrozen = false;
    }

    public void CamInViewPortExit()
    {
        ChangeParent(_defaultCamPos);
        _isFrozen = false;
    }

    public void CamAtMachineGun()
    {
        _isFrozen = true;
    }

    public void CamAtMachineGunExit()
    {
        _isFrozen = true;
    }


    private void ChangeParent(GameObject newParent)
    {
        
        transform.position = newParent.transform.position;
        transform.rotation = newParent.transform.rotation;
        transform.parent = newParent.transform;
    }
}
