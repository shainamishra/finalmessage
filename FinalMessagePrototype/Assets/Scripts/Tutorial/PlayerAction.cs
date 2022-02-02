using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Animator animator;
    public GameObject playeron;
    public GameObject dogon;
    public GameObject strikepoint;
    public GameObject rope;
    public GameObject ropeNPC;
    public GameObject freeNPC;

    // Start is called before the first frame update
    void Start()
    {
        ropeNPC = GameObject.Find("RopeNPC");
        //freeNPC = GameObject.Find("freeNPC");
    }

    // Update is called once per frame
    void Update()
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
    }

    void Act() 
    {
        animator.SetTrigger("Strike");
    }

    // Collision stuff
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "RopeInteract")
        {
            //Debug.Log("RopeInteract");
            ropeNPC.SetActive(false);
            freeNPC.SetActive(true);
        }
    }
}
