using UnityEngine;
public class AimerViewPort : ViewPort, IShootable
{
    [SerializeField] private Cannon _cannon;

    public override void Interact(CameraBehaviour cam)
    {
        cam.CamInAimViewPort(_viewPort);
    }

    public void Shoot()
    {
        _cannon.Shoot();
    }
}
