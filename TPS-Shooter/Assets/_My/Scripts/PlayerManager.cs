using Cinemachine;
using StarterAssets;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private StarterAssetsInputs input;

    [Header("Aim")]
    [SerializeField] private CinemachineVirtualCamera aimCam;
    [SerializeField] private GameObject aimImage;
    [SerializeField] private GameObject aimObj;
    [SerializeField] private float aimObjDis = 10f;
    [SerializeField] private LayerMask targetLayer;

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

            Vector3 targetPosition = Vector3.zero;
            Transform camTransform = Camera.main.transform;
            RaycastHit hit;

            if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity, targetLayer))
            {
                //Debug.Log("Name: " + hit.transform.gameObject.name);
                targetPosition = hit.point;
                aimObj.transform.position = hit.point;
            }
            else
            {
                targetPosition = camTransform.position + camTransform.forward * aimObjDis;
                aimObj.transform.position = camTransform.position + camTransform.forward * aimObjDis;
            }

            Vector3 targetAim = targetPosition;
            targetAim.y = transform.position.y;
            Vector3 aimDir = (targetAim - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDir, Time.deltaTime * 50f);
        }
        else
        {
            aimCam.gameObject.SetActive(false);
            aimImage.SetActive(false);
        }
    }
}
