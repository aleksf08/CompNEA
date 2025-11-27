using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //6 bullet images
    public Transform bullet1, bullet2, bullet3, bullet4, bullet5, bullet6;  //6 bullet images

    //Weapon reference to access ammo info
    public Weapon weapon;

    // Health bar reference
    public Slider healthBar;

    //Player reference to access health info
    public Player player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBullets(weapon.currentAmmo + weapon.tempAmmo);
        UpdateHealth(player.currentHealth);
    }

    public void UpdateBullets(int bulletsInMag)
    {
        // Show bullets based on the current bullet count
        if (bulletsInMag >= 1) bullet1.gameObject.SetActive(true);
        if (bulletsInMag >= 2) bullet2.gameObject.SetActive(true);
        if (bulletsInMag >= 3) bullet3.gameObject.SetActive(true);
        if (bulletsInMag >= 4) bullet4.gameObject.SetActive(true);
        if (bulletsInMag >= 5) bullet5.gameObject.SetActive(true);
        if (bulletsInMag == 6) bullet6.gameObject.SetActive(true);

        if (bulletsInMag < 6) bullet6.gameObject.SetActive(false);
        if (bulletsInMag < 5) bullet5.gameObject.SetActive(false);
        if (bulletsInMag < 4) bullet4.gameObject.SetActive(false);
        if (bulletsInMag < 3) bullet3.gameObject.SetActive(false);
        if (bulletsInMag < 2) bullet2.gameObject.SetActive(false);
        if (bulletsInMag < 1) bullet1.gameObject.SetActive(false);
    }

    public void UpdateHealth(int currentHealth)
    {
        healthBar.value = currentHealth;
    }









}