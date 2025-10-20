using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //Shooting variables
    public bool shootingDisabled;
    public float shootDelay = 0.5f;


    //Bullet variables
    public GameObject bulletPrefab;
    public GameObject firepoint;
    public float bulletPrefabLife = 2f;
    public float bulletVelocity = 30f;


    //Reload variables
    public float reloadTime = 0.5f;
    public int magSize = 6, currentAmmo, tempAmmo;
    bool magRemoved = false;
    private bool isReloading = false;
    

    void Awake()
    {
        shootingDisabled = false;

        currentAmmo = magSize;
    }

    void Update()
    {

        if (!shootingDisabled && Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
        }
        if (currentAmmo <= 0)
        {
            shootingDisabled = true;
        }
    }

    private void FireWeapon()
    {
        shootingDisabled = true;
        currentAmmo--;

        // Get the camera
        Camera cam = Camera.main;

        // Get the center of the screen
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        // Create a ray from the camera through the center of the screen
        Ray ray = cam.ScreenPointToRay(screenCenter);

        // Instantiate the bullet at the firepoint position with 90 degrees X rotation
        Quaternion bulletRotation = Quaternion.Euler(90f, 0f, 0f);
        GameObject bullet = Instantiate(bulletPrefab, firepoint.transform.position, bulletRotation);

        // Shoot the bullet in the camera's forward direction
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(ray.direction.normalized * bulletVelocity, ForceMode.Impulse);

        // Destroy the bullet after time
        Destroy(bullet, bulletPrefabLife);

        // Reset shooting ability after delay
        Invoke("ResetShooting", shootDelay);


    }

    
    private IEnumerator Reload()
    {
        isReloading = true;
        shootingDisabled = true;

        // Remove magazine
        magRemoved = true;
        tempAmmo = 0;
        Debug.Log("Magazine removed");

        // While mag is removed, let player press F to add bullets and G to insert mag
        while (magRemoved)
        {
            if (Input.GetKeyDown(KeyCode.F) && (currentAmmo + tempAmmo) < magSize)
            {
                tempAmmo += 1;
                Debug.Log("Bullet loaded into magazine. tempAmmo=" + tempAmmo);
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                currentAmmo = Mathf.Min(currentAmmo + tempAmmo, magSize);
                tempAmmo = 0;
                magRemoved = false;
                Debug.Log("Magazine inserted. Ammo=" + currentAmmo);
            }
            yield return null;
        }

        // Wait for cock input H
        bool cocked = false;
        while (!cocked)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                cocked = true;
                Debug.Log("Gun cocked");
            }
            yield return null;
        }

        shootingDisabled = false;
        isReloading = false;
    }

    public void ResetShooting()
    {
        shootingDisabled = false;
    }
}