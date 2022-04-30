using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// for the platform movement

public class ShadowKnight : MonoBehaviour
{

    // public float moveSpeed;
    // public Rigidbody2D player;
    // public Rigidbody2D shadow;
    // private Vector3 dir;
    //public NPCBehavior npc;
    // public Animator shadow;

    //public bool interactPressed = false;
    //public bool submitPressed = false;
    public GameObject shadow;
   

    
    // Awake is called after all objects are initialized. Called in random order
    private void Awake()
    {
        // player = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject (what the script is attached to) of type Rigidbody2D
    }

    // Start is called before the first frame update
    void Start()
    {
        // shadow = GetComponent<Rigidbody2D>();
        // dir = Vector3.forward; //Vector3(0, 0, 1)
        // dir = Vector3.left;
        // transform.position.x = -900;
        // transform.position.y = -325;
        // transform.position.z = 0;
        



    }

    // Update is called once per frame
    void Update()
    {
        // shadow.transform.position.y = -325;
        // shadow.transform.Translate(transform.position.x+3*Time.deltaTime,transform.position.y*0,0);
        // shadow.transform.position = transform.position + new Vector3(3 * Time.deltaTime, 3 * Time.deltaTime, 0);
        
        shadow.SetActive(true);
        shadow.transform.Translate(Vector3.left*Time.deltaTime*3);
        


        // transform.Translate(-1*3*Time.deltaTime,0,0);

            // Move
      

        // while (shadow.position.y - player.position.y >= 2.7){
       

        // Make it move 10 meters per second instead of 10 meters per frame...
        //     moveSpeed *= Time.deltaTime;

        // // Move translation along the object's z-axis
        //     transform.Translate(dir*moveSpeed);
        // }


        // Rotate around our y-axis

    }

  


 
    

    // private void move()
    // {
    //     player.velocity = new Vector2(moveDirection * moveSpeed, player.velocity.y);

    //     moveDirection = Input.GetAxis("Horizontal"); // from -1 to 1
    //     animator.SetFloat("Speed", Mathf.Abs(moveDirection));
    // }


}
