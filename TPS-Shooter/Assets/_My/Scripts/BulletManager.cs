using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Rigidbody bulletRigidbody;

    [SerializeField] private float moveSpeed = 10f;
    private float destroyTime = 3;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        destroyTime -= Time.deltaTime;

        if (destroyTime <= 0)
        {
            DestroyBullet();
        }

        BulletMove();
    }

    private void BulletMove()
    {
        bulletRigidbody.linearVelocity = transform.forward * moveSpeed;
    }

    private void DestroyBullet()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
        destroyTime = 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyBullet();
    }
}
