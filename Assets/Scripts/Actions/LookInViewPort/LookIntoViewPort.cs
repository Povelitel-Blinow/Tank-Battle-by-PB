using UnityEngine;

[CreateAssetMenu]
public class LookIntoViewPort : PlayerActions
{
    public override void DoIt(GameObject cam, GameObject viewPort, bool isAimViewPort)
    {
        if (isAimViewPort)
            cam?.GetComponent<CameraBehaviour>().CamInAimViewPort(viewPort);
        else
            cam?.GetComponent<CameraBehaviour>().CamInViewPort(viewPort);
    }
}
