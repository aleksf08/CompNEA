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

    //Wave variables
    public Text waveText;
    public int currentWave = 1;

    // Keybinds UI elements
    public Text step1Text; // Remove Mag
    public Text step2Text; // Insert Bullet
    public Text step3Text; // Insert Mag
    public Text step4Text; // Cock Gun



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateBullets(weapon.currentAmmo + weapon.tempAmmo);
        UpdateHealth(player.currentHealth);
        UpdateWaveText(currentWave);
    }

    //Update bullet UI based on current ammo
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

    //Update health bar UI based on current health
    public void UpdateHealth(int currentHealth)
    {
        healthBar.value = currentHealth;
    }

    //Update wave text UI
    public void UpdateWaveText(int waveNumber)
    {
        waveText.text = "Wave: " + waveNumber.ToString();
    }

    //Update keybinds UI
    public void UpdateKeybinds(int currentStep)
    {
        //Reset all steps be plain text (no highlight)
        step1Text.text = "Remove Mag (R)";
        step2Text.text = "Insert Bullet (F)";
        step3Text.text = "Insert Mag (G)";
        step4Text.text = "Cock Gun (H)";

        //Apply highlighting based on reload step
        if (currentStep == 1) step1Text.text = "<b>Remove Mag (R)</b>";
        else if (currentStep == 2) step2Text.text = "<b>Insert Bullet (F)</b>";
        else if (currentStep == 3) step3Text.text = "<b>Insert Mag (G)</b>";
        else if (currentStep == 4) step4Text.text = "<b>Cock Gun (H)</b>";
    }






}