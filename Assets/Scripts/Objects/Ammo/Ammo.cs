public class Ammo : TakeableObject
{
    public void Loaded()
    {
        Destroy(gameObject);
    }
}
