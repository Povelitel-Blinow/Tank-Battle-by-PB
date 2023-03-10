using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Turret _turret;
    public void TankAim(Vector2 rotation) { _turret.TurretAim(rotation); }
}
