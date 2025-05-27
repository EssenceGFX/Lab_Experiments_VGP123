using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("Ground Check Settings")]
    [SerializeField, Range(0.01f, 0.75f)] private float checkWidth = 0.75f;
    [SerializeField, Range(0.01f, 0.2f)] private float checkHeight = 0.05f;
    [SerializeField] private LayerMask isGroundLayer;

    private Transform groundCheck;

    void Start()
    {
        // Create GroundCheck point at the bottom center of the player
        GameObject newGameObject = new GameObject("GroundCheck");
        newGameObject.transform.SetParent(transform);
        newGameObject.transform.localPosition = Vector3.zero;
        groundCheck = newGameObject.transform;
    }

    public bool isGrounded()
    {
        Vector2 boxCenter = (Vector2)groundCheck.position + Vector2.down * (checkHeight / 2f);
        Vector2 boxSize = new Vector2(checkWidth, checkHeight);

        // BoxCast downwards, very short distance (0.05f) to detect ground just below feet
        RaycastHit2D[] hits = Physics2D.BoxCastAll(boxCenter, boxSize, 0f, Vector2.down, 0.05f, isGroundLayer);

        foreach (var hit in hits)
        {
            if (hit.collider == null) continue;

            // Check the surface normal of the hit point
            // Physics2D.BoxCast doesn't provide normal directly, so we use raycast from slightly above
            RaycastHit2D normalHit = Physics2D.Raycast(hit.point + Vector2.up * 0.1f, Vector2.down, 0.2f, isGroundLayer);
            if (normalHit.collider != null)
            {
                // If normal is mostly upward (less than 45 degrees angle), count as ground
                if (Vector2.Angle(normalHit.normal, Vector2.up) < 45f)
                {
                    return true;
                }
            }
            else
            {
                // If we can't get a normal, fallback to trusting the BoxCast hit as ground
                return true;
            }
        }

        return false;
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.green;
        Vector2 size = new Vector2(checkWidth, checkHeight);
        Gizmos.DrawWireCube(groundCheck.position, size);
    }
#endif
}
