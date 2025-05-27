using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Bullet")]
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private GameObject bulletObj;
    [SerializeField] private float maxShootDelay = 0.2f;
    [SerializeField] private float currentShootDelay = 0.2f;
    [SerializeField] private Text bulletText;
    private int maxBullet = 30;
    private int currentBullet = 0;

    [Header("Weapon FX")]
    [SerializeField] private GameObject weaponFlashFX;
    [SerializeField] private Transform bulletCasePoint;
    [SerializeField] private GameObject bulletCaseFX;
    [SerializeField] private Transform weaponClipPoint;
    [SerializeField] private GameObject weaponClipFX;

    void Start()
    {
        instance = this;

        currentShootDelay = 0;
        InitBullet();
    }

    void Update()
    {
        bulletText.text = currentBullet + " / " + maxBullet;
    }

    public void Shooting(Vector3 targetPosition)
    {
        currentShootDelay += Time.deltaTime;

        if (currentShootDelay < maxShootDelay || currentBullet <= 0)
            return;

        currentBullet -= 1;
        currentShootDelay = 0;

        Instantiate(weaponFlashFX, bulletPoint);
        Instantiate(bulletCaseFX, bulletCasePoint);

        Vector3 aim = (targetPosition - bulletPoint.position).normalized;
        Instantiate(bulletObj, bulletPoint.position, Quaternion.LookRotation(aim, Vector3.up));
    }

    public void ReloadClip()
    {
        Instantiate(weaponClipFX, weaponClipPoint);
        InitBullet();
    }

    private void InitBullet()
    {
        currentBullet = maxBullet;
    }
}
