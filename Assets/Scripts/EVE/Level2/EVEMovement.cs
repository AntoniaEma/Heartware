using UnityEngine;

public class EVEMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveSpeed = 3f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Salt vertical
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("isFlying", true);
        }

        // Revine la Idle când cade
        if (rb.velocity.y < 0.01f)
        {
            anim.SetBool("isFlying", false);
        }

        // Mișcare stânga-dreapta
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Întoarcere sprite
        if (moveX != 0)
        {
            sr.flipX = moveX < 0;
        }
    }
}
