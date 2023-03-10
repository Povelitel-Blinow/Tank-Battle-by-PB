using UnityEngine;

[CreateAssetMenu]
public class UseMachineGun : PlayerActions
{
    public override void DoIt(Camera cam)
    {
        cam?.GetComponent<CameraBehaviour>().CamAtMachineGun();
    }
}
