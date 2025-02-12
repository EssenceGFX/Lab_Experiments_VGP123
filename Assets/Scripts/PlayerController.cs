using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class Player : MonoBehaviour
{
    // Movement
    [Range(3, 10)]
    public float speed = 5.0f;
    public float jumpForce = 7.0f;

    // Component References
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    // Ground Check
    [Range(0.01f, 0.1f)]
    public float groundCheckRadius = 0.02f;
    public LayerMask isGroundLayer;
    public bool isGrounded = false;
    private Transform groundCheck;

    // Attacks
    public bool isAttacking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (jumpForce < 0) jumpForce = 7.0f;

        // Initialize Ground Check
        GameObject newGameObject = new GameObject();
        newGameObject.transform.SetParent(transform);
        newGameObject.transform.localPosition = Vector3.zero;
        newGameObject.name = "GroundCheck";
        groundCheck = newGameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsGrounded();

        float hInput = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(hInput * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // Attack Animation Triggers
        if (Input.GetButtonDown("Fire1"))
            anim.SetTrigger("ThrowAttack");

        if (Input.GetButtonDown("Fire2"))
            anim.SetTrigger("SitAttack");

        // Sprite Flipping
        if (hInput != 0) sr.flipX = (hInput < 0);

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("speed", Mathf.Abs(hInput));
    }

    void CheckIsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
    }
}
