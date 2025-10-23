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
    public bool magRemoved = false, magEmpty = false, isReloading = false;

    //MuzzleFlashEffect
    public GameObject muzzleEffect;

    //Animator
    public Animator animator;

    
    

    void Awake()
    {
        shootingDisabled = false;

        currentAmmo = magSize;

        animator = GetComponent<Animator>();

        
    }

    void Update()
    {

        //shoot gun
        if (!shootingDisabled && Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }

        //reload gun
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
        }

        //ammo empty check
        if (currentAmmo <= 0)
        {
            shootingDisabled = true;
            magEmpty = true;
        }

        //shooting with an empty mag
        if (magEmpty == true && Input.GetKeyDown(KeyCode.Mouse0) && !isReloading)
        {
            Debug.Log("Mag empty (no ammo)");
            //empty mag click sound
        }
    }

    private void FireWeapon()
    {
        //play muzzleEffect animation
        muzzleEffect.GetComponent<ParticleSystem>().Play();
        //play recoil animation
        animator.SetTrigger("RECOIL");
        
        // Deduct ammo and disable shooting
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
        animator.SetTrigger("INSPECT");
        isReloading = true;
        shootingDisabled = true;

        // Remove magazine
        magRemoved = true;
        tempAmmo = 0;
        Debug.Log("Magazine removed");
        animator.SetTrigger("REMOVE MAG");


        // While mag is removed, let player press F to add bullets and G to insert mag
        while (magRemoved)
        {
            if (Input.GetKeyDown(KeyCode.F) && (currentAmmo + tempAmmo) < magSize)
            {
                tempAmmo += 1;
                Debug.Log("Bullet loaded into magazine. tempAmmo=" + tempAmmo);
                animator.SetTrigger("INSERT BULLET");
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                currentAmmo = Mathf.Min(currentAmmo + tempAmmo, magSize);
                tempAmmo = 0;
                magRemoved = false;
                Debug.Log("Magazine inserted. Ammo=" + currentAmmo);
                animator.SetTrigger("INSERT MAG");
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
                animator.SetTrigger("COCK GUN");
            }
            yield return null;
        }

        Invoke("ResetShooting", shootDelay);
        isReloading = false;
        magEmpty = false;
    }

    public void ResetShooting()
    {
        shootingDisabled = false;
    }
}