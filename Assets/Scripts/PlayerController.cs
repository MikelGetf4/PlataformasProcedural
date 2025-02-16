using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 8f;
    public float moveSpeed = 5f;
    public float jumpCutMultiplier = 0.5f;
    public float groundCheckDistance = 0.3f;  // Distancia del Raycast para comprobar el suelo
    public LayerMask groundLayer;  // Capa del suelo para el raycast

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumping;
    private int jumpCount;  // Contador para el doble salto

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(1 * moveSpeed, rb.velocity.y);

        // Comprobamos si estamos tocando el suelo usando un Raycast
        CheckGrounded();

        // Salto
        if (Input.GetButtonDown("Jump"))
        {
            // Si el jugador está en el suelo o ha realizado un salto
            if (isGrounded || jumpCount < 2)
            {
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount++;  // Aumentamos el contador de saltos
            }
        }

        // Salto más corto si se suelta el botón rápido
        if (Input.GetButtonUp("Jump") && isJumping && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCutMultiplier);
            isJumping = false;
        }
    }

    void CheckGrounded()
    {
        // Lanza un Raycast desde una posición cerca de la base del jugador
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.5f); // Ajusta la posición Y según el tamaño del jugador
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, groundLayer);  // Filtramos por la capa del suelo

        if (hit.collider != null)
        {
            isGrounded = true;
            jumpCount = 0;  // Reseteamos el contador cuando el jugador toca el suelo
        }
        else
        {
            isGrounded = false;
        }

        // Para visualizar el raycast (opcional para depuración)
        Debug.DrawRay(rayOrigin, Vector2.down * groundCheckDistance, Color.red);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
