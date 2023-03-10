    using UnityEngine;

public class ViewPort : InteractableObject
{
   [Header("viewPort")]
   [SerializeField] private GameObject _viewPort;
   public override void Act(Camera cam)
   {
       _action.DoIt(cam, _viewPort);
   }
}
