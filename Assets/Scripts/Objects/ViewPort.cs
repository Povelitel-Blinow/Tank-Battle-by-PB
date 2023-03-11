using UnityEngine;

public class ViewPort : InteractableObject
{
   [Header("viewPort")]
   [SerializeField] private GameObject _viewPort;
   [SerializeField] private bool _isAimViewPort = false;

   public override void Act(GameObject cam)
   {
       _action.DoIt(cam, _viewPort, _isAimViewPort);
   }
}
