using UnityEngine;

public class ViewPort : InteractableObject
{
   [SerializeField] protected GameObject _viewPort;

    public override void Interact(CameraBehaviour cam)
    {
        cam.CamInViewPort(_viewPort);
    }
}
