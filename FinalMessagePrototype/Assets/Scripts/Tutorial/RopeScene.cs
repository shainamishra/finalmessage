using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScene : MonoBehaviour
{
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
        
    }

    // Collision stuff
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "StrikeZone")
        {
            //Debug.Log("RopeInteract");
            ropeNPC.SetActive(false);
            freeNPC.SetActive(true);
        }
    }
}
