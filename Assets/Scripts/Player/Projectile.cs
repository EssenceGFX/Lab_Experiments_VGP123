using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField, Range(1, 20)] private float lifetime = 1.0f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void SetVelocity(Vector2 velocity)
    {
        GetComponent<Rigidbody2D>().linearVelocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitObject = collision.gameObject;

        // Ignore player and powerup collisions
        if (hitObject.CompareTag("Player") || hitObject.CompareTag("Powerup"))
            return;

        // Destroy enemy if hit
        if (hitObject.CompareTag("Enemy"))
        {
            Destroy(hitObject); // Destroys the enemy GameObject
        }

        // Destroy the projectile in all other cases
        Destroy(gameObject);
    }
}
