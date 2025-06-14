using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = Vector3.zero;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.Lives--;
            }
            Debug.Log("Player hit death barrier -1 life & teleported to (0, 0, 0)");
        }
    }
}
