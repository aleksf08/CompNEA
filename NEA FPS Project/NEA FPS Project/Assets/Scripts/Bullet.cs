using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletPrefabLife = 2f;

    public void Start()
    {
        Destroy(gameObject, bulletPrefabLife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit!");
            
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDamage();
            }

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall hit!");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit!");

            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(15);

            Destroy(gameObject);
        }
    }
    
}
