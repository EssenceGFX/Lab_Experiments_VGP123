using UnityEngine;
using System.Collections;

public class beeEnemy : MonoBehaviour
{
    public float attackRange = 10f;
    public GameObject projectilePrefab;
    public Transform Stinger;
    private float projectileSpeed = 5f;

    private Transform player;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FindPlayer());
    }

    private IEnumerator FindPlayer()
    {
        while (player == null)
        {
            GameObject foundPlayer = GameObject.FindWithTag("Player");
            if (foundPlayer != null)
            {
                player = foundPlayer.transform;
                Debug.Log("Player found and assigned.");
                yield break;
            }

            yield return new WaitForSeconds(0.5f); // Retry every 0.5 seconds
        }
    }

    public void Shoot()
    {
        if (player == null)
        {
            Debug.LogWarning("Cannot shoot: Player not yet assigned.");
            return;
        }

        // Flip sprite to face player using SpriteRenderer
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = player.position.x > transform.position.x;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer > attackRange)
        {
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        direction.y = 0;
        direction.Normalize();

        GameObject projectile = Instantiate(projectilePrefab, Stinger.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }
    }
}