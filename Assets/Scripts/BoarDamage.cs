using UnityEngine;

public class boarHurtbox : MonoBehaviour
{
    public float knockbackForceX = 5f;
    public float knockbackForceY = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the enemy's hurtbox — applying damage and knockback");
        }
    }
}
