using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private IconLauncher nearbyIcon;
     private ExitButton nearbyExit;
   private UpdateButton nearbyUpdate;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        if(Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
      
        if (nearbyIcon != null && Input.GetKeyDown(KeyCode.E))
        {
       
            nearbyIcon.launchApp();
        }
       
        if (nearbyExit != null && Input.GetKeyDown(KeyCode.E))
        {
             nearbyExit.closeApp();
        }
       if (nearbyExit != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbyExit.closeApp();
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IconLauncher>(out IconLauncher launcher))
        {
            nearbyIcon = launcher;
        }
        if (other.TryGetComponent<ExitButton>(out ExitButton close))
         {
             nearbyExit = close;
         }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<IconLauncher>() != null)
        {
            nearbyIcon = null;
           
        }
         if (other.GetComponent<ExitButton>() != null)
         {
             nearbyExit = null;
         }
    }

    private void Flip()
    {
        if(isFacingRight && horizontalInput < 0 || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
