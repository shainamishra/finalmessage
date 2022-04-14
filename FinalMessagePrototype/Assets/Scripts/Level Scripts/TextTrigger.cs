using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public Collider2D player; 
    public Collider2D npc; 
    public GameObject canvas; 
    
    void Start()
    {
        DisableCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        if(npc.IsTouching(player))
        {
            EnableCanvas();
        }
        
    }
    
    void DisableCanvas() 
    {
        canvas.SetActive(false);
    }

    void EnableCanvas() 
    {
        canvas.SetActive(true);
    }

}
