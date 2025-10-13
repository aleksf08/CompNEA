using UnityEngine;

public class Weapon : MonoBehaviour
{

    //Shooting variables
    public bool shootingDisabled;
    public float shootDelay = 0.5f;


    //Bullet variables
    public GameObject bulletPrefab;
    public GameObject firepoint;
    public float bulletVelocity = 30f;
    public float bulletPrefabLife = 2f;

    void Awake()
    {
        shootingDisabled = false;
    }

    void Update()
    {
        
        if (!shootingDisabled && Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        shootingDisabled = true;

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
    
    void ResetShooting()
    {
        shootingDisabled = false;
    }
}