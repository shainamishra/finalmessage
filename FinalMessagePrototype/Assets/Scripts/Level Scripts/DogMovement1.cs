using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.UI;
using System.IO;

public class DogMovement1 : MonoBehaviour
{
    public float moveSpeed;
    public GameObject dogon;
    public GameObject dog;
    public Animator animator;

    public static Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection = 0f;
    public InputField finalMessage;

    public FMOD.Studio.EventInstance pettingAudio;

    // Awake is called after all objects are initialized. Called in random order
    private void Awake()
    {
        pettingAudio = RuntimeManager.CreateInstance("event:/PlayerAudio/Dog/Pup-Idle");
        rb = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject (what the script is attached to) of type Rigidbody2D
    }

    // Start is called before the first frame update
    void Start()
    {
        if (LevelLoader.Prev == true)
        {
            Debug.Log("true");
            //facingRight = false;
            dog.transform.position = new Vector3(7.0f, -1.2f, 0.0f);
            flipChara();
        }
    }

    // Update is called once per frame
    void Update()
    {        
        if (finalMessage.isFocused && Input.GetKeyDown("space")){
            return;
        
        }
        else if (Input.GetKeyDown("space")) {
            if(dogon.activeSelf == true){
                dogon.SetActive(false);
                animator.SetFloat("Speed", 0);
                
            }
            else if(dogon.activeSelf == false){
                dogon.SetActive(true);
                switchSFX();
            }
        }

        // Get Pet
        pet();

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

            if (Input.GetMouseButton(0) == true)
            {
                Act();
            }
        }
    }

    void pet()
    {
        if (Input.GetKey("p"))
        {
            animator.SetTrigger("Pet");
            if (!AudioManager.isPlaying(pettingAudio)) {
                pettingAudio.start();
            }
        }

    }

    void Act()
    {
        if (TextTrigger.Speaking == false)
        {
            animator.SetTrigger("Bark");
        }
    }

    // public void whileInput() 
    // {
    //     facingRight = facingRight;
    //     transform.Rotate(0f, 0f, 0f);
    //     rb.velocity = new Vector3(0, 0, 0);
    // }

    private void switchSFX() 
    {
        AudioManager.instance.PlaySound("event:/UI/CharacterSwitch");
    
    } 

    // private void pettingSFX() {
    //     AudioManager.instance.PlaySound("event:/PlayerAudio/Dog/Pup-Idle");
    // }

    private void move()
    {
        // rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(finalMessage.isFocused){
            rb.velocity = new Vector3(0,0,0);
        }
        else {
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        }
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
        // facingRight = !facingRight; //inverse boolean
        // transform.Rotate(0f, 180f, 0f);
        if(finalMessage.isFocused){
            transform.Rotate(0f, 0f, 0f);
        }
        else{
            facingRight = !facingRight; //inverse boolean
            transform.Rotate(0f, 180f, 0f);
        }
    }


}
