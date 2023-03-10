using UnityEngine;

public class MachineGun : InteractableObject
{
    [SerializeField] private GameObject _stand;
    [SerializeField] private float _maxHorizontalRotation;
    public override void Act(Camera cam)
    {
        transform.localRotation = Quaternion.Euler(cam.transform.rotation.eulerAngles.x, 0, 0);
        float yRot = cam.transform.parent.rotation.eulerAngles.y;
        if (yRot < _maxHorizontalRotation || yRot > 360-_maxHorizontalRotation)
            _stand.transform.rotation = Quaternion.Euler(-90, yRot, 0);
    }
}
