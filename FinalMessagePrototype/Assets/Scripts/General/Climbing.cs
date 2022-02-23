using UnityEngine;

public class Climbing : MonoBehaviour
{
    public Animator animator;

    private float vertical;
    private float speed = 3f;
    private bool canClimb; 
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (canClimb && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }

        if (Input.GetKeyDown("w") || Input.GetKeyDown("s"))
        {
            if (Input.GetKeyUp("w") || Input.GetKeyUp("s"))
            {
                animator.enabled = false;
            }
        }
        else
        {
            animator.enabled = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            animator.SetBool("IsClimbing", true);
            if (Input.GetKey("w") || Input.GetKey("s"))
            {
                animator.enabled = true;
            }
            if (Input.GetKeyUp("w") || Input.GetKeyUp("s"))
            {
                animator.enabled = false;
            }
        }
        else
        {
            rb.gravityScale = 1f;
            animator.SetBool("IsClimbing", false);
            animator.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CanClimb"))
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CanClimb"))
        {
            canClimb = false;
            isClimbing = false;
        }
    }
}