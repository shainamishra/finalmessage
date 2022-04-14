using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public Collider2D player; 
    public Collider2D npc; 
    public Button start; 
    public Button cont; 
    public Button option1; 
    public Button option2; 
    public Button option3; 
    public Button option4; 
    public GameObject canvas; 
    
    void Start()
    {
        // hide text
        DisableCanvas();

        // hide start button
        start.gameObject.SetActive(false);

        // start button listeners
        Button startBTN = start.GetComponent<Button>();
        startBTN.onClick.AddListener(TaskOnClick);

        // continue button listeners
        Button continueBTN = cont.GetComponent<Button>();
        continueBTN.onClick.AddListener(TaskOnClick2);
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the player touches the NPC
        if(player.IsTouching(npc))
        {
            // show the talk button
            start.gameObject.SetActive(true);
        }
    }
    
    // hide the canvas
    void DisableCanvas() 
    {
        canvas.SetActive(false);
    }

    // show the canvas
    void EnableCanvas() 
    {
        canvas.SetActive(true);
    }

    // when the start button is clicked
    void TaskOnClick()
    {
        // hide the start button
        start.gameObject.SetActive(false);
        // show the text canvas
        EnableCanvas();
    }
    
    // when the start button is clicked
    void TaskOnClick2()
    {
        // show the text canvas
        option1.gameObject.SetActive(true);
        option2.gameObject.SetActive(true);
        option3.gameObject.SetActive(true);
        option4.gameObject.SetActive(true);
    }

}
