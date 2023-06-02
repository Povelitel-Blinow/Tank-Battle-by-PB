public class InteractableObject : SelectableObject
{
    private const int InteractableObjectLayer = 6;

    private void Start()
    {
        gameObject.layer = InteractableObjectLayer;
    }

    public virtual void Interact(CameraBehaviour cam) { }
}
