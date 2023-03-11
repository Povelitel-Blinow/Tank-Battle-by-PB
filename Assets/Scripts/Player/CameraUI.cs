using UnityEngine;

public class CameraUI : MonoBehaviour
{
    [SerializeField] private GameObject _aim;
    [SerializeField] private GameObject _view;

    public void InViewPort()
    {
        _view.SetActive(true);
    }

    public void InAimViewPort()
    {
        _aim.SetActive(true);
    }

    public void NotInViewPort()
    {
        _aim.SetActive(false);
        _view.SetActive(false);
    }
}
