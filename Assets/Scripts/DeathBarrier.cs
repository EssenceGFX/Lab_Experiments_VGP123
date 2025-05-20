using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = Vector3.zero;
            Debug.Log("Player hit death barrier — teleported to (0, 0, 0)");
        }
    }
}
