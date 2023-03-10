using UnityEngine;

public class CannonRotationChecker : MonoBehaviour
{
    [SerializeField] private GameObject _aimerViewPort;
    private void OnTransformParentChanged()
    {
        _aimerViewPort.transform.rotation = transform.rotation;
    }
}
