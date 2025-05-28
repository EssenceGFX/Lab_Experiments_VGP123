using UnityEngine;

public class boarHurtbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the enemy's hurtbox, -1 life");

            if (GameManager.Instance != null)
            {
                GameManager.Instance.Lives--;
            }
        }
    }
}
