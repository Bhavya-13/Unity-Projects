using UnityEngine;
using UnityEngine.InputSystem;

public class EraserPlayer : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 6f;
    public float jumpPower = 12f;
    
    [Header("Jump Settings")]
    public int maxJumps = 1;
    private int jumpsRemaining;
    public bool hasDoubleJump = false;
    
    [Header("Ground Check")]
    public LayerMask groundLayer;
    
    [Header("Erasing")]
    public float eraseRadius = 1.5f;
    public float eraseDamage = 20f;
    
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3f;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        
        jumpsRemaining = maxJumps;
    }
    
    void Update()
    {
        // Read keyboard input directly
        float moveInput = 0f;
        
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            moveInput = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            moveInput = 1f;
        
        // Movement
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        
        // Flip
        if (moveInput > 0.1f && !facingRight) Flip();
        if (moveInput < -0.1f && facingRight) Flip();
        
        // Jump (only if jumps remaining)
        if (Keyboard.current.spaceKey.wasPressedThisFrame && jumpsRemaining > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            jumpsRemaining--;
            Debug.Log($"Jump! Remaining: {jumpsRemaining}");
        }
        
        // Erase
        if (Keyboard.current.eKey.isPressed)
        {
            Erase();
        }
    }
    
    // Detect landing via collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if we hit ground layer
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
            jumpsRemaining = hasDoubleJump ? 2 : maxJumps;
            Debug.Log($"Landed! Jumps reset to: {jumpsRemaining}");
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;
        }
    }
    
    void Erase()
    {
        Vector2 erasePoint = (Vector2)transform.position + (facingRight ? Vector2.right : Vector2.left) * 0.8f;
        Collider2D[] hits = Physics2D.OverlapCircleAll(erasePoint, eraseRadius);
        
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(eraseDamage * Time.deltaTime);
                }
            }
            
            if (hit.CompareTag("Ink"))
            {
                Destroy(hit.gameObject);
            }
            
            if (hit.CompareTag("PowerUp"))
            {
                CollectPowerUp(hit.gameObject);
            }
        }
    }
    
    void CollectPowerUp(GameObject powerUp)
    {
        PowerUpItem item = powerUp.GetComponent<PowerUpItem>();
        if (item != null && item.powerUpType == PowerUpType.DoubleJump)
        {
            UnlockDoubleJump();
            Destroy(powerUp);
        }
    }
    
    public void UnlockDoubleJump()
    {
        hasDoubleJump = true;
        jumpsRemaining = 2;
        Debug.Log("Double Jump Unlocked!");
    }
    
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector2 erasePoint = (Vector2)transform.position + (facingRight ? Vector2.right : Vector2.left) * 0.8f;
        Gizmos.DrawWireSphere(erasePoint, eraseRadius);
    }
}