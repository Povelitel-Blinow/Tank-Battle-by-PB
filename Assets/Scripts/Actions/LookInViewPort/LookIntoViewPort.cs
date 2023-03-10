using UnityEngine;

[CreateAssetMenu]
public class LookIntoViewPort : PlayerActions
{
    public override void DoIt(Camera cam, GameObject viewPort)
    {
        cam?.GetComponent<CameraBehaviour>().CamInViewPort(viewPort);  
    }
}
