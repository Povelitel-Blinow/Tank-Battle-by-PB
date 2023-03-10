using UnityEngine;

[CreateAssetMenu]
public class Aimer : CrewMemberRole
{
    public override void CrewWork(Vector2 rotation)
    {
        _tankScript.TankAim(rotation);
    }
}
