using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShellHead : MonoBehaviour
{
    [SerializeField] private GameObject _effect;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }
    public void Shoot(float force)
    {
        _rb.useGravity = true;
        _rb.AddForce(-transform.up * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
