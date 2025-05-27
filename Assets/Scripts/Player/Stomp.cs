using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public float bounceForce = 14f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.attachedRigidbody.linearVelocity.y < 0)
        {
            Debug.Log("Player stomped on enemy!");

            // Call the bounce method on the player
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Bounce(bounceForce);
            }

            Destroy(transform.root.gameObject);
        }
    }
}
