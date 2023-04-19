using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;


public class ThirdPersonShooter : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject aimCamera;
    public float rotateSpeed = 15;
    public Transform debugTransform;
    public float aimMaxDistance = 100;
    public GameObject bulletPrefab;
   
    StarterAssetsInputs input;
    Camera mainCam;
    ThirdPersonController tpc;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<StarterAssetsInputs>();
        mainCam = Camera.main;
        tpc = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aimPosition = Vector3.zero;
        Vector2 screenCenterPos = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = mainCam.ScreenPointToRay(screenCenterPos);
        if(Physics.Raycast(ray, out RaycastHit hit, aimMaxDistance))
		{
            debugTransform.position = hit.point;
            aimPosition = hit.point;
		}
		else
		{
            debugTransform.position = ray.origin + ray.direction * aimMaxDistance;
            aimPosition = ray.origin + ray.direction * aimMaxDistance;

        }
		if (input.aim)
		{
            
            animator.SetLayerWeight(1, 1);
            tpc.SetRotateOnMove(false);
            aimCamera.SetActive(true);
            float yawCamera = mainCam.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), Time.deltaTime * rotateSpeed);
		}
		else
		{
            
            
            animator.SetLayerWeight(1, 0);
            aimCamera.SetActive(false);
            tpc.SetRotateOnMove(true);
        }

		if (input.shoot && input.aim)
		{
            input.shoot = false;
            Vector3 bulletDirection = (aimPosition - bulletSpawn.position).normalized;
            Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.LookRotation(bulletDirection));
		}
    }
}
