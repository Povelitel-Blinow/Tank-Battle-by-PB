using UnityEngine;

public class MachineGun : InteractableObject
{
    [SerializeField] private GameObject _stand;
    [SerializeField] private float _maxHorizontalRotation;
    public override void Act(GameObject cam)
    {
        transform.localRotation = Quaternion.Euler(cam.transform.localRotation.eulerAngles.x, 0, 0);
        float yRot = cam.transform.parent.localRotation.eulerAngles.y;
        if (yRot < _maxHorizontalRotation || yRot > 360-_maxHorizontalRotation)
            _stand.transform.localRotation = Quaternion.Euler(0, 0, yRot);
    }
}
