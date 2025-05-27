using UnityEngine;

public class Jump : MonoBehaviour
{

    Rigidbody2D rb;
    Player pc;

    [SerializeField, Range(2, 8)] private float jumpHeight = 6;
    [SerializeField, Range(1, 10)] private float jumpFallForce = 6;

    float timeHeld;
    float maxHoldTime = 0.5f;
    float jumpInputTime = 0.0f;
    float calculatedJumpForce;

    public bool jumpCancelled = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<Player>();

        calculatedJumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.isGrounded) jumpCancelled = false;

        if (Input.GetButton("Jump"))
        {
            jumpInputTime = Time.time;
            timeHeld += Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump"))
        {
            timeHeld = 0;
            jumpInputTime = 0;

            if (rb.linearVelocity.y < -10) return;
            jumpCancelled = true;
        }

        if (jumpInputTime != 0 && (jumpInputTime + timeHeld) < (jumpInputTime + maxHoldTime))
        {
            if (pc.isGrounded)
            {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(new Vector2(0, calculatedJumpForce), ForceMode2D.Impulse);
            }
        }

        if (jumpCancelled) rb.AddForce(Vector2.down * jumpFallForce);
    }
}
