using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;

    private bool movingRight = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set sprite direction to match movement
        spriteRenderer.flipX = movingRight;
    }

    void Update()
    {
        Vector2 moveDirection = movingRight ? Vector2.right : Vector2.left;
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Barrier"))
        {
            Flip();
        }

        void Flip()
        {
            movingRight = !movingRight;
            spriteRenderer.flipX = movingRight;
        }
    }
}
