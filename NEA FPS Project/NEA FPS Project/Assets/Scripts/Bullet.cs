using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        //Bullet collides with enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit!");
            Destroy(gameObject);
        }
        //Bullet collides with environment
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall hit!");
            Destroy(gameObject);
        }

    }

    
}
