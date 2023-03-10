using UnityEngine;

public class CrewMemberRole : ScriptableObject
{
    protected Transform _seat;
    protected Tank _tankScript;

    public virtual void TakeASeat(GameObject player, Transform seat, Tank tank) 
    {
        _seat = seat;
        _tankScript = tank;
        PlayerSit(player);
    }

    private void PlayerSit(GameObject player)
    {
        player.transform.position = _seat.transform.position;
        player.transform.parent = _seat.transform;
    }

    public virtual void CrewWork(Vector2 rotation) { }
    public virtual void CrewWork(float state) { }
}
