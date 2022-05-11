using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TatikArarDialogue : MonoBehaviour
{
    // text tracking stuff
    private bool textOn = false;
    public static bool Speaking = false;

    // colliders for triggers
    public Collider2D player; 
    public Collider2D npc; 

    // UI buttons
    public Button start; 
    public Button cont; 
    public Button prev; 
    public Button next; 
    public Button close; 

    // dialogue options
    public Button option1; 
    public Button option2; 
    public Button option3; 
    public Button option4; 
    public Button option5; 
    public Button option6; 
    public Button option7; 
    public Button option8; 
    public Button option9; 
    public Button option10; 
    public Button option11; 

    // text stuff
    public GameObject NPCname; 
    public GameObject canvas; 
    public GameObject finalText; 

    // int stuff
    int contClicked = 0;
    int options = 0;
    public int sentences;
    
    void Start()
    {
        // hide text
        DisableCanvas();

        // start button
            // hide start button
            start.gameObject.SetActive(false);

            // start button listeners
            Button startBTN = start.GetComponent<Button>();
            startBTN.onClick.AddListener(startTask);

        // UI buttons
            // continue button listeners
            Button continueBTN = cont.GetComponent<Button>();
            continueBTN.onClick.AddListener(continueTask);

            // close button listeners
            Button closeBTN = close.GetComponent<Button>();
            closeBTN.onClick.AddListener(closeTask);

            // prev button listeners
            Button prevBTN = prev.GetComponent<Button>();
            prevBTN.onClick.AddListener(prevTask);

            // next button listeners
            Button nextBTN = next.GetComponent<Button>();
            nextBTN.onClick.AddListener(nextTask);

        // options
            // option button listeners
            Button btn1 = option1.GetComponent<Button>();
            btn1.onClick.AddListener(TaskOnClick1);

            Button btn2 = option2.GetComponent<Button>();
            btn2.onClick.AddListener(TaskOnClick2);

            Button btn3 = option3.GetComponent<Button>();
            btn3.onClick.AddListener(TaskOnClick3);

            Button btn4 = option4.GetComponent<Button>();
            btn4.onClick.AddListener(TaskOnClick4);

            Button btn5 = option5.GetComponent<Button>();
            btn5.onClick.AddListener(TaskOnClick5);

            Button btn6 = option6.GetComponent<Button>();
            btn6.onClick.AddListener(TaskOnClick6);

            Button btn7 = option7.GetComponent<Button>();
            btn7.onClick.AddListener(TaskOnClick7);

            Button btn8 = option8.GetComponent<Button>();
            btn8.onClick.AddListener(TaskOnClick8);

            Button btn9 = option9.GetComponent<Button>();
            btn9.onClick.AddListener(TaskOnClick9);

            Button btn10 = option10.GetComponent<Button>();
            btn10.onClick.AddListener(TaskOnClick10);

            Button btn11 = option11.GetComponent<Button>();
            btn11.onClick.AddListener(TaskOnClick11);
    }

    // Update is called once per frame
    void Update()
    {
        // if the player touches the NPC
        StartDialogue();
    }

    // show start button
    void StartDialogue()
    {
        if(player.IsTouching(npc) && (textOn == false))
        {
            // show the talk button
            start.gameObject.SetActive(true);

            TextTrigger.Speaking = true;
        }
    }
    
    // close the canvas
    void closeTask() 
    {
        contClicked = 0;
        TextTrigger.Speaking = false;
        textOn = false;

        DisableCanvas();
        StartDialogue();
    }
    
    // hide the canvas
    void DisableCanvas() 
    {
        canvas.SetActive(false);
        close.gameObject.SetActive(false);
    }

    // show the canvas
    void EnableCanvas() 
    {
        canvas.SetActive(true);
        close.gameObject.SetActive(true);
    }

    // show the canvas
    void EnableOptions() 
    {
        // show the option buttons
        option1.gameObject.SetActive(true);
        option2.gameObject.SetActive(true);
        option3.gameObject.SetActive(true);
        option4.gameObject.SetActive(true);
    }

    // show the canvas
    void DiaableOptions() 
    {
        // show the option buttons
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);
    }
    
    // when the start button is clicked
    void startTask()
    {
        // hide the start button
        start.gameObject.SetActive(false);
        textOn = true;

        // show the text canvas
        EnableCanvas();
    }
    
    // when the continue button is clicked
    void continueTask()
    {
            Debug.Log("fuck");
        if (contClicked == sentences)
        {
            //remove continue button
            cont.gameObject.SetActive(false);
        }
        else
        {
            contClicked = contClicked + 1;
        }
    }   

    // when the prev button is clicked
    void prevTask()
    {
        if(options == 0)
        {
            prev.gameObject.SetActive(false);
        }
        else if (options == 1)
        {
            prev.gameObject.SetActive(true);
        }
        else if (options == 2)
        {
            prev.gameObject.SetActive(true);
        }
    }
        
    // when the next button is clicked
    void nextTask()
    {
        if(options == 0)
        {
            next.gameObject.SetActive(true);

        }
        else if (options == 1)
        {
            next.gameObject.SetActive(true);

        }
        else if (options == 2)
        {
            next.gameObject.SetActive(false);
        }
    }

    void TaskOnClick1()
    {

    }
    void TaskOnClick2()
    {
        
    }
    void TaskOnClick3()
    {
        
    }
    void TaskOnClick4()
    {
        
    }
    void TaskOnClick5()
    {
        
    }
    void TaskOnClick6()
    {
        
    }
    void TaskOnClick7()
    {
        
    }
    void TaskOnClick8()
    {
        
    }
    void TaskOnClick9()
    {
        
    }
    void TaskOnClick10()
    {
        
    }
    void TaskOnClick11()
    {
        
    }
}

