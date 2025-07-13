using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D body;
    private Vector3 originalScale;
    private Animator anim;

    private int jumpCount;
    [SerializeField] private int maxJumps = 2;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Mișcare stânga-dreapta
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Întoarcerea jucătorului
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);

        // Săritură + double jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumps)
        {
            Jump();
        }

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", IsGrounded());
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        anim.SetTrigger("jump");
        jumpCount++;
    }

    private bool IsGrounded()
    {
        // Verificare simplă: grounded dacă viteza pe Y e aproape zero sau negativă
        return body.velocity.y == 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0; // Resetăm la atingerea solului
        }
    }
}
