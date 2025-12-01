using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    public GameOverManager gameOverManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            gameOverManager.TriggerGameOver();
        }
    }
}
