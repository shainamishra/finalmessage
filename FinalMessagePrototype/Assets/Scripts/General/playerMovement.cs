using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject playeron;
    public Animator animator;
    public GameObject strikepoint;
    public GameObject reachzone;
    //public NPCBehavior npc;

    //public bool interactPressed = false;
    //public bool submitPressed = false;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection = 0f;
    
    // Awake is called after all objects are initialized. Called in random order
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject (what the script is attached to) of type Rigidbody2D
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     /*   
        if (DialogueManager.GetInstance().dialogueisPlaying)
        {
            return;
        }*/
        // swapping between knight and dog
        if (Input.GetKeyDown("space"))
        {
            if (playeron.activeSelf == true)
            {
                playeron.SetActive(false);
                animator.SetFloat("Speed", 0);
            }
            else if (playeron.activeSelf == false)
            {
                playeron.SetActive(true);
            }
        }

        // Left Click (0) to strike and Right Click (1) to grab objects
        if (playeron.activeSelf == true)
        {
            if (Input.GetMouseButton(0) == true)
            {
                strikepoint.SetActive(true);
                Act();
            }
            else
            {
                strikepoint.SetActive(false);
            }
            if (Input.GetMouseButton(1) == true)
            {
                reachzone.SetActive(true);
            }
            else
            {
                reachzone.SetActive(false);
            }
        }
        if (playeron.activeSelf == true)
        {

            processInputs();

            // Animate
            animate();

            // Move
            move();

        }

    }

    void Act()
    {
        animator.SetTrigger("Strike");
    }

    private void move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(rb.velocity.x != 0){
            if(!FindObjectOfType<AudioManager>().isPlaying()){
                FindObjectOfType<AudioManager>().Play("Footsteps-Armor");
            }
        }
        else if(rb.velocity.x == 0){
            FindObjectOfType<AudioManager>().Stop("Footsteps-Armor");
        }
    }

    private void animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            flipChara();
        }
        else if (moveDirection < 0 && facingRight)
        {
            flipChara();
        }
    }

    private void processInputs()
    {
        moveDirection = Input.GetAxis("Horizontal"); // from -1 to 1
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
    }

    private void flipChara()
    {
        facingRight = !facingRight; //inverse boolean
        transform.Rotate(0f, 180f, 0f);
    }

    /*private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "NPC")
        {
            Debug.Log("touched NPC");
            //other.gameObject.GetComponent<NPCBehavior>().Talk();
            // NPCBehavior npc = GameObject.Find("NPC").GetComponent<NPCBehavior>();
            // npc.Talk();
        }
    }*/

    public void Die() {
        playeron.SetActive(false);
        SceneManager.LoadScene("1StartScene");
    }
}
