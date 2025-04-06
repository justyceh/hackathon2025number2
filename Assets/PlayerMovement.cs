using UnityEngine;

// Added comment
public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 8f;
    private float jumpingPower = 24f;
    private bool isFacingRight = true;

    private IconLauncher nearbyIcon;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        //animations

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.Play("start_click");
            }
            else if (Input.GetKey(KeyCode.E))
            {
                anim.Play("hold_click");

            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                anim.Play("end_click");
            }
            else
            {
                anim.Play("run_left");
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.Play("start_click");
            }
            else if (Input.GetKey(KeyCode.E))
            {
                anim.Play("hold_click");

            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                anim.Play("end_click");
            }
            else
            {
                anim.Play("run_right");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.Play("start_click");
            }
            else if (Input.GetKey(KeyCode.E))
            {
                anim.Play("hold_click");

            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                anim.Play("end_click");
            }
            else
            {
                anim.Play("idle");
            }
        }


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
            nearbyIcon.LaunchApp();
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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<IconLauncher>() != null)
        {
            nearbyIcon = null;
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
