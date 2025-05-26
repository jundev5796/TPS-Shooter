using Cinemachine;
using StarterAssets;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private StarterAssetsInputs input;

    [Header("Aim")]
    [SerializeField] private CinemachineVirtualCamera aimCam;
    [SerializeField] private GameObject aimImage;

    void Start()
    {
        input = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        AimCheck();
    }

    private void AimCheck()
    {
        if (input.aim)
        {
            aimCam.gameObject.SetActive(true);
            aimImage.SetActive(true);
        }
        else
        {
            aimCam.gameObject.SetActive(false);
            aimImage.SetActive(false);
        }
    }
}
