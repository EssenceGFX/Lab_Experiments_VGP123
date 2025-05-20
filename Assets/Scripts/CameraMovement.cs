using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float minXPos;
    [SerializeField] private float maxXPos;

    [SerializeField] private float minYPos;
    [SerializeField] private float maxYPos;

    public Transform playerRef;

    void Update()
    {
        if (!playerRef) return;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(playerRef.position.x, minXPos, maxXPos);
        pos.y = Mathf.Clamp(playerRef.position.y, minYPos, maxYPos);
        transform.position = pos;
    }
}
