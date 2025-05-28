using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float minXPos;
    [SerializeField] private float maxXPos;
    [SerializeField] private float minYPos;
    [SerializeField] private float maxYPos;

    private Transform playerRef;

    private void Awake()
    {
        // Subscribe to the event
        GameManager.Instance.OnPlayerControllerCreated += AssignPlayer;
    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnPlayerControllerCreated -= AssignPlayer;
        }
    }

    private Player AssignPlayer(Player playerInstance)
    {
        playerRef = playerInstance.transform;
        return playerInstance;
    }

    void Update()
    {
        if (!playerRef) return;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(playerRef.position.x, minXPos, maxXPos);
        pos.y = Mathf.Clamp(playerRef.position.y, minYPos, maxYPos);
        transform.position = pos;
    }
}
