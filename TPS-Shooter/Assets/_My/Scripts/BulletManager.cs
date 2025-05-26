using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Rigidbody bulletRigidbody;

    [SerializeField] private float moveSpeed = 10f;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        bulletRigidbody.linearVelocity = transform.forward * moveSpeed;
    }
}
