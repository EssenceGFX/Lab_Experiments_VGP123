using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
[RequireComponent (typeof(GroundCheck), typeof(Jump))]
public class Player : MonoBehaviour
{
    // Movement
    [Range(3, 9)]
    public float speed = 7.0f;
    [Range(3, 10)]
    public float jumpForce = 8.0f;

    // Component References
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private GroundCheck grdChk;

    public bool isGrounded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        grdChk = GetComponent<GroundCheck>();

        if (jumpForce < 0) jumpForce = 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);
        CheckIsGrounded();

        float hInput = Input.GetAxis("Horizontal");

        // Check if an attack animation is currently playing
        bool isAttacking = curPlayingClips.Length > 0 &&
                           (curPlayingClips[0].clip.name == "ThrowAttack" || curPlayingClips[0].clip.name == "SitAttack");

        if (!isAttacking) // Prevent input while attacking
        {
            rb.linearVelocity = new Vector2(hInput * speed, rb.linearVelocity.y);

            if (Input.GetButtonDown("Fire1"))
            {
                if (isGrounded)
                    anim.SetTrigger("ThrowAttack");
                else
                    anim.SetTrigger("SitAttack");
                    GetComponent<Jump>().jumpCancelled = true;
            }
        }

        // Sprite Flipping
        if (hInput != 0) sr.flipX = (hInput < 0);

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("speed", Mathf.Abs(hInput));
    }

    void CheckIsGrounded()
    {
        isGrounded = grdChk.isGrounded();
    }
}
