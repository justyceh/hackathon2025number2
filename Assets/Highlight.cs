using UnityEngine;

public class Highlight : MonoBehaviour
{
    public GameObject highlight; // Drag the sprite object here in the inspector
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Ensure the sprite is initially invisible
        spriteRenderer = highlight.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the specific object you want
        if (other.gameObject.CompareTag("Player")) // Replace "Player" with the tag of your object
        {
            // Make the sprite visible
            spriteRenderer.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Optionally, make the sprite invisible again when the object leaves the trigger
        if (other.gameObject.CompareTag("Player")) // Replace "Player" with the tag of your object
        {
            spriteRenderer.enabled = false;
        }
    }

}
