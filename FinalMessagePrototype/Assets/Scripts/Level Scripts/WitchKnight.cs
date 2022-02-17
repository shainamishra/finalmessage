using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for the platform movement

public class WitchKnight : MonoBehaviour
{

    public Collider2D LeftMover;
    public Collider2D RightMover;
    public Collider2D rock1;
    public Collider2D rock2;
    public Collider2D player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!rock1.IsTouching(LeftMover) && Input.GetMouseButton(1) == false) 
        {
            rock1.gameObject.SetActive(false);
        }*/

        if ((LeftMover.IsTouching(rock1)) || (LeftMover.IsTouching(player)) && !rock2.IsTouching(RightMover)) 
        {
            if (LeftMover.transform.position.y > -3.375)
            {
                LeftMover.transform.position += new Vector3(0.0f, -0.01f, 0.0f);
            }
            if (RightMover.transform.position.y < 8.125)
            {
                RightMover.transform.position += new Vector3(0.0f, 0.01f, 0.0f);
            }
        }
        if ((RightMover.IsTouching(rock2)) || (RightMover.IsTouching(player)) && !rock1.IsTouching(LeftMover) && !rock2.IsTouching(LeftMover))
        {
            if (RightMover.transform.position.y > -3.375)
            {
                RightMover.transform.position += new Vector3(0.0f, -0.01f, 0.0f);
            }
            if (LeftMover.transform.position.y < 8.125)
            {
                LeftMover.transform.position += new Vector3(0.0f, 0.01f, 0.0f);
            }
        }
    }
}
