using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;

public class dogMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject dogon;
    public Animator animator;

    //public UnityEvent soundEvent;
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
        if (Input.GetKeyDown("space")) {
            if(dogon.activeSelf == true){
                dogon.SetActive(false);
                animator.SetFloat("Speed", 0);

            }
            else if(dogon.activeSelf == false){
                dogon.SetActive(true);
                
                switchSFX();
                // Debug.Log("Test");
                
            }
        }

        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            // stay put
            rb.gravityScale = 0f;
        }
        else
        {
            // apply gravity
            rb.gravityScale = 1f;
        }

        if (dogon.activeSelf == true)
        {
            // Get player inputs
            processInputs();

            // Animate
            animate();

            // Move
            move();
        }
    }

    //play character switchSFX
    private void switchSFX() 
    {
        AudioManager.instance.PlaySound("event:/UI/CharacterSwitch");
    
    } 

    private void move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        // if(rb.velocity.x != 0){
        //     if(!FindObjectOfType<AudioManager>().isPlaying()){
        //         FindObjectOfType<AudioManager>().Play("Footsteps-Dog");
        //     }
        // }
        // else if(rb.velocity.x == 0){
        //     FindObjectOfType<AudioManager>().Stop("Footsteps-Dog");
        // }
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
}
