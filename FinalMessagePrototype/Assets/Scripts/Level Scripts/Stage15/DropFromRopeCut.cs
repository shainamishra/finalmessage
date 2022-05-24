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
        body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        body.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ropeCut.status){
            body.constraints = RigidbodyConstraints2D.None;
            body.constraints = RigidbodyConstraints2D.FreezeRotation;
            body.gravityScale = 1;
        }
    }
}
