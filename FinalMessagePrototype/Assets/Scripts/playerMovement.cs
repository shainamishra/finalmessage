using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject playeron;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;

    // Awake is called after all objects are initialized. Called in random order
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject (what the script is attached to) of type Rigidbody2D
    }

    // Start is called before the first frame update
    void Start()
    {

                Debug.Log("player = " + playeron.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            if(playeron.activeSelf == true){
                playeron.SetActive(false);
                Debug.Log("player = " + playeron.activeSelf);
            }
            else if(playeron.activeSelf == false){
                playeron.SetActive(true);
                Debug.Log("player = " + playeron.activeSelf);
            }
        }

        if (playeron.activeSelf == true)
        {
            // Get player inputs
            processInputs();

            // Animate
            animate();

            // Move
            move();
        }
    }

    private void move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
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
    }

    private void flipChara()
    {
        facingRight = !facingRight; //inverse boolean
        transform.Rotate(0f, 180f, 0f);
    }
}
