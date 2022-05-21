using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFromRopeCut : MonoBehaviour
{
    public GameObject rope;

    RopeCut ropeCut;
    Rigidbody2D gravity;

    // Start is called before the first frame update
    void Start()
    {
        ropeCut = rope.GetComponent<RopeCut>();
        gravity = gameObject.GetComponent<Rigidbody2D>();
        gravity.gravityScale = 0;

        //gravity.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        if(ropeCut.status){
            //gravity.constraints = RigidbodyConstraints2D.None;
            gravity.gravityScale = 1;
        }
    }
}
