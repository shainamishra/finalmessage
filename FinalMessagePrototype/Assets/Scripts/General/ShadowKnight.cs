using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// for the platform movement

public class ShadowKnight : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D player;
    public Rigidbody2D shadow;
    private Vector3 dir;
    //public NPCBehavior npc;

    //public bool interactPressed = false;
    //public bool submitPressed = false;

    
    // Awake is called after all objects are initialized. Called in random order
    private void Awake()
    {
        player = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject (what the script is attached to) of type Rigidbody2D
    }

    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.forward; //Vector3(0, 0, 1)


    }

    // Update is called once per frame
    void Update()
    {

            // Move
      

        while (shadow.position.x - player.position.x >= 2.7){
       

        // Make it move 10 meters per second instead of 10 meters per frame...
            moveSpeed *= Time.deltaTime;

        // Move translation along the object's z-axis
            transform.Translate(dir*moveSpeed);
        }

        // Rotate around our y-axis

    }

  


 
    

    // private void move()
    // {
    //     player.velocity = new Vector2(moveDirection * moveSpeed, player.velocity.y);

    //     moveDirection = Input.GetAxis("Horizontal"); // from -1 to 1
    //     animator.SetFloat("Speed", Mathf.Abs(moveDirection));
    // }


}
