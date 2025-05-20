using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.attachedRigidbody.linearVelocityY < 0)
        {
            Debug.Log("Player stomped on enemy!");
            Destroy(transform.root.gameObject); // Remove the entire enemy parent
        }
    }
}
