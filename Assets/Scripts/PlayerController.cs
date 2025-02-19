using UnityEngine;
using UnityEngine.SceneManagement;  

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 8f;
    public float moveSpeed = 5f;
    public float jumpCutMultiplier = 0.5f;
    public float groundCheckDistance = 0.3f;
    public LayerMask groundLayer; 

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumping;
    private int jumpCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(1 * moveSpeed, rb.velocity.y);


        CheckGrounded();

        // Salto
        if (Input.GetButtonDown("Jump"))
        {

            if (isGrounded || jumpCount < 2)
            {
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount++;
            }
        }


        if (Input.GetButtonUp("Jump") && isJumping && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCutMultiplier);
            isJumping = false;
        }
    }

    void CheckGrounded()
    {

        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.5f);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, groundLayer);

        if (hit.collider != null)
        {
            isGrounded = true;
            jumpCount = 0;
        }
        else
        {
            isGrounded = false;
        }


        Debug.DrawRay(rayOrigin, Vector2.down * groundCheckDistance, Color.red);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Muerte"))
        {

            GameManager.instance.SaveScore();  


            Debug.Log("¡Has muerto!");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
