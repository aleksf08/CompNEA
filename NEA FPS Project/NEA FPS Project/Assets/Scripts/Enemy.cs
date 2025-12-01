using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float timeBetweenShots;
    private float firetimer; 
    private float enemyHealth;
    public WaveManager waveManager;

    void Start()
    {
        timeBetweenShots = 2f;
        firetimer = timeBetweenShots;
        enemyHealth = 100f;

        waveManager = GameObject.Find("GameManager").GetComponent<WaveManager>();
    }

    void Update()
    {
        if (firetimer > 0)
        {
            firetimer -= Time.deltaTime;
        }
    
    }

    public void Attack()
    {
        if (firetimer <= 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
            //Fire the bullet forward
            Rigidbody rb = bullet.GetComponent<Rigidbody>();    
            rb.AddForce(firePoint.forward * 20f, ForceMode.Impulse);

            firetimer = timeBetweenShots;
        }
    }


    public void takeDamage()
    {
        enemyHealth -= 25f;
        if (enemyHealth <= 0f)
        {
            Destroy(gameObject);
            waveManager.AddKill();
        }
    }








}