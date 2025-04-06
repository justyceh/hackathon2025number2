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
     private GameObject PaintButton1;
     private PaintButton nearbyPaintButton1;

     private EraserButton nearbyEraserButton;
    private UpdateButton nearbyUpdate;
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
       
            nearbyIcon.launchApp();
        }
       if (nearbyExit != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbyExit.closeApp();
        }
        if (nearbyUpdate != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbyUpdate.LoadNextScene();
             Debug.Log("Update button clicked!!!!");
        }
        if (nearbyPaintButton1 != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbyPaintButton1.generatePlatform();
        }
        if (nearbyEraserButton != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Eraser button clicked!!!!");
            nearbyEraserButton.Erase();
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
         if (other.TryGetComponent<UpdateButton>(out UpdateButton update))
         {
             nearbyUpdate = update;
         }
         if (other.TryGetComponent<PaintButton>(out PaintButton paintButton1))
         {
             nearbyPaintButton1 = paintButton1;
         }
         if (other.TryGetComponent<EraserButton>(out EraserButton eraserButton))
         {
             nearbyEraserButton = eraserButton;
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
         if (other.GetComponent<UpdateButton>() != null)
         {
             nearbyUpdate = null;
         }
         if (other.GetComponent<PaintButton>() != null)
         {
             nearbyPaintButton1 = null;
         }
         if (other.GetComponent<EraserButton>() != null)
         {
             nearbyEraserButton = null;
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
