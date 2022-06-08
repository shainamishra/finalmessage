using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using UnityEngine.UI;
using System.IO;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject playeron;
    public GameObject player;
    public Animator animator;
    public GameObject strikepoint;
    public GameObject reachzone;
    GameObject interactionDisplay;
    Canvas canvas;
    public static Rigidbody2D rb;

    public FMOD.Studio.EventInstance pettingAudio;
    // public TimeManager time;
    // public NPCBehavior npc;

    // public bool interactPressed = false;
    // public bool submitPressed = false;
    // public static bool check = TimeManager.TimesUp;

    private bool facingRight = true;
    private float moveDirection = 0f;
    
    // Awake is called after all objects are initialized. Called in random order
    private void Awake()
    {
        pettingAudio = RuntimeManager.CreateInstance("event:/PlayerAudio/Knight/PupPetting");
        rb = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject (what the script is attached to) of type Rigidbody2D
    }

    // Start is called before the first frame update
    void Start()
    {
        interactionDisplay = gameObject.transform.Find("InteractionDisplay").gameObject;
        //canvas = interactionDisplay.GetComponent<Canvas>();
        //canvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
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
                switchSFX();
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

    // This block controls the little interactable indicator
    void OnTriggerStay2D(Collider2D collider){
        if(collider.tag == "PressE")
        {
            interactionDisplay.SetActive(true);
        }

        if (collider.gameObject.name == "PetZone")
        {
            // Pet the Dog
            pet();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(SceneManager.GetActiveScene().buildIndex != 21)
        {
            interactionDisplay.SetActive(false);
        }
    }

    void pet()
    {
        if (Input.GetKey("p"))
        {
            animator.SetTrigger("Pet");
            if (!AudioManager.isPlaying(pettingAudio)) 
            {
                pettingAudio.start();
            }
        }
    }

    void Act()
    {
        if (TextTrigger.Speaking == false)
        {
            animator.SetTrigger("Strike");
        }
    }

    private void switchSFX() 
    {
        AudioManager.instance.PlaySound("event:/UI/CharacterSwitch");
    
    }

    // private void pettingSFX() {
    //     AudioManager.instance.PlaySound("event:/PlayerAudio/Knight/PupPetting");
    // }
    
    private void move()
    {
        if(TimeManager.TimesUp == true){
            rb.velocity = new Vector3(0,0,0);
        }
        else {
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        }            
        
        // rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        // if(rb.velocity.x != 0){
        //     if(!FindObjectOfType<AudioManager>().isPlaying()){
        //         FindObjectOfType<AudioManager>().Play("Footsteps-Armor");
        //     }
        // }
        // else if(rb.velocity.x == 0){
        //     FindObjectOfType<AudioManager>().Stop("Footsteps-Armor");
        // }
    }

    // public void whileInput() 
    // {
    //     facingRight = facingRight;
    //     transform.Rotate(0f, 0f, 0f);
    //     rb.velocity = new Vector3(0, 0, 0);

    // }


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

    // private void flipChara()
    // {
    //     // facingRight = !facingRight; //inverse boolean
    //     // transform.Rotate(0f, 180f, 0f);
        
    //         facingRight = !facingRight; //inverse boolean
    //         transform.Rotate(0f, 180f, 0f);
        
    // }
    private void flipChara()
    {
        // facingRight = !facingRight; //inverse boolean
        // transform.Rotate(0f, 180f, 0f);
        
        if(TimeManager.TimesUp == true){
            transform.Rotate(0f, 0f, 0f);
        }
        else{
            facingRight = !facingRight; //inverse boolean
            transform.Rotate(0f, 180f, 0f);
            interactionDisplay.transform.Rotate(0f, 180f, 0f);
        }
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
        TimeManager.startingTime = 300;
        SceneManager.LoadScene("1StartScene");
        LevelLoader.deathCount += 1;
    }
}
