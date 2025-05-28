using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        string pickupName = gameObject.name.Replace("(Clone)", "").Trim();

        switch (pickupName)
        {
            case "Coin":
                Debug.Log("Picked up Coin +1 score");
                // Add score logic here
                break;

            case "Leaf":
                Debug.Log("Picked up Leaf: Speed & Jump Height Increased");
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.speed += 1.0f;
                    player.jumpForce += 1.0f;
                }
                break;

            case "Gem":
                Debug.Log("Picked up Gem +1 Life");
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.Lives++;
                }
                break;

            default:
                Debug.Log($"Picked up unknown item: {pickupName}");
                break;
        }

        Destroy(gameObject);
    }
}
