using UnityEngine;

public class Shoot : MonoBehaviour
{

    SpriteRenderer sr;

    [SerializeField] private Vector2 initShotVelocity = Vector2.zero;

    [SerializeField] private Transform spawnPointRight;
    [SerializeField] private Transform spawnPointLeft;

    [SerializeField] private Projectile projectilePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (initShotVelocity == Vector2.zero)
        {
            Debug.Log("Initial Shot Velocity has been changed to a default value");
            initShotVelocity.x = 7.0f;
        }

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log($"Please set default values on {gameObject.name}");
    }

    public void Fire()
    {
        Projectile curProjectile;
        Vector2 shotVelocity = initShotVelocity;

        if (!sr.flipX)
        {
            curProjectile = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
        }
        else
        {
            curProjectile = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            shotVelocity.x *= -1;
        }

        curProjectile.SetVelocity(shotVelocity);
    }
}
