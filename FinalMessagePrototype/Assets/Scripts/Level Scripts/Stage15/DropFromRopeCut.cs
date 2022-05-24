using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFromRopeCut : MonoBehaviour
{
    public GameObject rope;

    RopeCut ropeCut;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        ropeCut = rope.GetComponent<RopeCut>();
        body = gameObject.GetComponent<Rigidbody2D>();
        // I'm using both constraints and gravity because the player needs to be prevented from throwing the rock off the screen,
        // but using *only* constraints tends to not kick in until the player collides with the object, even if gravity is on as well.
        // So, the setting of free constraints, *then* reactivate gravity gets Unity to actually drop it on cue.
        body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        body.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ropeCut.status){
            // Free the constraints, then immediately lock the rotation agian to prevent it from going everywhere.
            body.constraints = RigidbodyConstraints2D.None;
            body.constraints = RigidbodyConstraints2D.FreezeRotation;
            body.gravityScale = 1;
        }
    }
}
