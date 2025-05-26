using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Bullet")]
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private GameObject bulletObj;
    [SerializeField] private float maxShootDelay = 0.2f;
    [SerializeField] private float currentShootDelay = 0.2f;

    [Header("Weapon FX")]
    [SerializeField] private GameObject weaponFlashFX;
    [SerializeField] private Transform bulletCasePoint;
    [SerializeField] private GameObject bulletCaseFX;

    void Start()
    {
        instance = this;

        currentShootDelay = 0;
    }

    void Update()
    {
        
    }

    public void Shooting(Vector3 targetPosition)
    {
        currentShootDelay += Time.deltaTime;

        if (currentShootDelay < maxShootDelay)
            return;

        currentShootDelay = 0;

        Instantiate(weaponFlashFX, bulletPoint);
        Instantiate(bulletCaseFX, bulletCasePoint);

        Vector3 aim = (targetPosition - bulletPoint.position).normalized;
        Instantiate(bulletObj, bulletPoint.position, Quaternion.LookRotation(aim, Vector3.up));
    }
}
