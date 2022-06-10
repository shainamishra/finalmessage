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

    public GameObject dialogueManager;

    // text stuff
    public GameObject NPCname; 
    public GameObject canvas; 
    public GameObject text; 
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

            sentences = start.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences.Length - 2;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player touches the NPC
        StartDialogue();
        // if the player stops touching the NPC
        HideDialogue();
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
    
    // hide start button
    void HideDialogue()
    {
        if(!player.IsTouching(npc) && (textOn == false))
        {
            // hide the talk button
            start.gameObject.SetActive(false);

            TextTrigger.Speaking = false;
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
    void EnableOptions0() 
    {
        // show options page 1
        options = 0;

        // show the option buttons page 1
        option1.gameObject.SetActive(true);
        option2.gameObject.SetActive(true);
        option3.gameObject.SetActive(true);
        option4.gameObject.SetActive(true);

        // hide the option buttons page 2
        option5.gameObject.SetActive(false);
        option6.gameObject.SetActive(false);
        option7.gameObject.SetActive(false);
        option8.gameObject.SetActive(false);

        // hide the option buttons page 3
        option9.gameObject.SetActive(false);
        option10.gameObject.SetActive(false);
        option11.gameObject.SetActive(false);

        // show next and prev buttons
        prev.gameObject.SetActive(false);
        next.gameObject.SetActive(true);
    }
    
    // show the canvas
    void EnableOptions1() 
    {
        // show options page 2
        options = 1;

        // hide the option buttons page 1
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);

        // show the option buttons page 2
        option5.gameObject.SetActive(true);
        option6.gameObject.SetActive(true);
        option7.gameObject.SetActive(true);
        option8.gameObject.SetActive(true);

        // hide the option buttons page 3
        option9.gameObject.SetActive(false);
        option10.gameObject.SetActive(false);
        option11.gameObject.SetActive(false);

        // show next and prev buttons
        prev.gameObject.SetActive(true);
        next.gameObject.SetActive(true);
    }
    
    // show the canvas
    void EnableOptions2() 
    {
        // show options page 3
        options = 2;

        // show the option buttons
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);

        // show the option buttons page 2
        option5.gameObject.SetActive(false);
        option6.gameObject.SetActive(false);
        option7.gameObject.SetActive(false);
        option8.gameObject.SetActive(false);

        // show the option buttons page 3
        option9.gameObject.SetActive(true);
        option10.gameObject.SetActive(true);
        option11.gameObject.SetActive(true);

        // show next and prev buttons
        prev.gameObject.SetActive(true);
        next.gameObject.SetActive(false);
    }

    // show the canvas
    void DisableOptions() 
    {
        // hide the option buttons
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);

        // hide the option buttons page 2
        option5.gameObject.SetActive(false);
        option6.gameObject.SetActive(false);
        option7.gameObject.SetActive(false);
        option8.gameObject.SetActive(false);

        // hide the option buttons page 3
        option9.gameObject.SetActive(false);
        option10.gameObject.SetActive(false);
        option11.gameObject.SetActive(false);

        // show next and prev buttons
        prev.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
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
        if (contClicked == sentences)
        {
            //remove continue button
            cont.gameObject.SetActive(false);
            EnableOptions0();
        
            //hide NPC name tag
            NPCname.gameObject.SetActive(false);
            //text.gameObject.SetActive(false);
            
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
            
        }
        else if (options == 1)
        {
            EnableOptions0();
        }
        else if (options == 2)
        {
            EnableOptions1();
        }
    }
        
    // when the next button is clicked
    void nextTask()
    {
        if(options == 0)
        {
            EnableOptions1();
        }
        else if (options == 1)
        {
            EnableOptions2();

        }
        else if (options == 2)
        {
            
        }
    }

    // What is Mount Arar?
    void TaskOnClick1()
    {
        //jump to new dialogue
        contClicked = 0;
        sentences = option1.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences.Length - 2;
        dialogueManager.gameObject.GetComponent<DialogueManager>().StartDialogue(option1.gameObject.GetComponent<DialogueTrigger>().dialogue);
        // hide buttons
        DisableOptions();
        // show name tag
        NPCname.gameObject.SetActive(true);
        // show continue button
        cont.gameObject.SetActive(true);
        // show final text
        //finalText.gameObject.SetActive(true);
        // disable NPC box collider
        npc.GetComponent<BoxCollider2D>().enabled = false;

        //TextTrigger.Speaking = false;
    }
    // Who is the Lonely Climber?
    void TaskOnClick2()
    {
        //jump to new dialogue
        contClicked = 0;
        sentences = option2.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences.Length - 2;
        dialogueManager.gameObject.GetComponent<DialogueManager>().StartDialogue(option2.gameObject.GetComponent<DialogueTrigger>().dialogue);
        // hide buttons
        DisableOptions();
        // show name tag
        NPCname.gameObject.SetActive(true);
        // show continue button
        cont.gameObject.SetActive(true);
        // show final text
        //finalText.gameObject.SetActive(true);
        // disable NPC box collider
        npc.GetComponent<BoxCollider2D>().enabled = false;

        //TextTrigger.Speaking = false;
    }
    // Who is the Witch Knight?
    void TaskOnClick3()
    {
        //jump to new dialogue
        contClicked = 0;
        sentences = option3.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences.Length - 2;
        dialogueManager.gameObject.GetComponent<DialogueManager>().StartDialogue(option3.gameObject.GetComponent<DialogueTrigger>().dialogue);
        // hide buttons
        DisableOptions();
        // show name tag
        NPCname.gameObject.SetActive(true);
        // show continue button
        cont.gameObject.SetActive(true);
        // show final text
        //finalText.gameObject.SetActive(true);
        // disable NPC box collider
        npc.GetComponent<BoxCollider2D>().enabled = false;

        //TextTrigger.Speaking = false;
    }
    // What are the keys?
    void TaskOnClick4()
    {
        //jump to new dialogue
        contClicked = 0;
        sentences = option4.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences.Length - 2;
        dialogueManager.gameObject.GetComponent<DialogueManager>().StartDialogue(option4.gameObject.GetComponent<DialogueTrigger>().dialogue);
        // hide buttons
        DisableOptions();
        // show name tag
        NPCname.gameObject.SetActive(true);
        // show continue button
        cont.gameObject.SetActive(true);
        // show final text
        //finalText.gameObject.SetActive(true);
        // disable NPC box collider
        npc.GetComponent<BoxCollider2D>().enabled = false;

        //TextTrigger.Speaking = false;
    }
    // What is the Witch Key?
    void TaskOnClick5()
    {
        //jump to new dialogue
        contClicked = 0;
        sentences = option5.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences.Length - 2;
        dialogueManager.gameObject.GetComponent<DialogueManager>().StartDialogue(option5.gameObject.GetComponent<DialogueTrigger>().dialogue);
        // hide buttons
        DisableOptions();
        // show name tag
        NPCname.gameObject.SetActive(true);
        // show continue button
        cont.gameObject.SetActive(true);
        // show final text
        //finalText.gameObject.SetActive(true);
        // disable NPC box collider
        npc.GetComponent<BoxCollider2D>().enabled = false;

        //TextTrigger.Speaking = false;
    }
    // What is the Fallens Falchion?
    void TaskOnClick6()
    {
        //jump to new dialogue
        contClicked = 0;
        sentences = option6.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences.Length - 2;
        dialogueManager.gameObject.GetComponent<DialogueManager>().StartDialogue(option6.gameObject.GetComponent<DialogueTrigger>().dialogue);
        // hide buttons
        DisableOptions();
        // show name tag
        NPCname.gameObject.SetActive(true);
        // show continue button
        cont.gameObject.SetActive(true);
        // show final text
        //finalText.gameObject.SetActive(true);
        // disable NPC box collider
        npc.GetComponent<BoxCollider2D>().enabled = false;

        //TextTrigger.Speaking = false;
    }
    // What is the Seekers Chime Staff?
    void TaskOnClick7()
    {
        //jump to new dialogue
        contClicked = 0;
        sentences = option7.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences.Length - 2;
        dialogueManager.gameObject.GetComponent<DialogueManager>().StartDialogue(option7.gameObject.GetComponent<DialogueTrigger>().dialogue);
        // hide buttons
        DisableOptions();
        // show name tag
        NPCname.gameObject.SetActive(true);
        // show continue button
        cont.gameObject.SetActive(true);
        // show final text
        //finalText.gameObject.SetActive(true);
        // disable NPC box collider
        npc.GetComponent<BoxCollider2D>().enabled = false;

        //TextTrigger.Speaking = false;
    }
    // What is the Ember Heart?
    void TaskOnClick8()
    {
        //jump to new dialogue
        contClicked = 0;
        sentences = option8.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences.Length - 2;
        dialogueManager.gameObject.GetComponent<DialogueManager>().StartDialogue(option8.gameObject.GetComponent<DialogueTrigger>().dialogue);
        // hide buttons
        DisableOptions();
        // show name tag
        NPCname.gameObject.SetActive(true);
        // show continue button
        cont.gameObject.SetActive(true);
        // show final text
        //finalText.gameObject.SetActive(true);
        // disable NPC box collider
        npc.GetComponent<BoxCollider2D>().enabled = false;

        //TextTrigger.Speaking = false;
    }
    // What is a Final Message?
    void TaskOnClick9()
    {
        //jump to new dialogue
        contClicked = 0;
        sentences = option9.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences.Length - 2;
        dialogueManager.gameObject.GetComponent<DialogueManager>().StartDialogue(option9.gameObject.GetComponent<DialogueTrigger>().dialogue);
        // hide buttons
        DisableOptions();
        // show name tag
        NPCname.gameObject.SetActive(true);
        // show continue button
        cont.gameObject.SetActive(true);
        // show final text
        //finalText.gameObject.SetActive(true);
        // disable NPC box collider
        npc.GetComponent<BoxCollider2D>().enabled = false;

        //TextTrigger.Speaking = false;
    }
    // Who is the Exhausted Adventurer?
    void TaskOnClick10()
    {
        //jump to new dialogue
        contClicked = 0;
        sentences = option10.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences.Length - 2;
        dialogueManager.gameObject.GetComponent<DialogueManager>().StartDialogue(option10.gameObject.GetComponent<DialogueTrigger>().dialogue);
        // hide buttons
        DisableOptions();
        // show name tag
        NPCname.gameObject.SetActive(true);
        // show continue button
        cont.gameObject.SetActive(true);
        // show final text
        //finalText.gameObject.SetActive(true);
        // disable NPC box collider
        npc.GetComponent<BoxCollider2D>().enabled = false;

        //TextTrigger.Speaking = false;
    }
    // Who is the Seeker of Eternity?
    void TaskOnClick11()
    {
        //jump to new dialogue
        contClicked = 0;
        sentences = option11.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences.Length - 2;
        dialogueManager.gameObject.GetComponent<DialogueManager>().StartDialogue(option11.gameObject.GetComponent<DialogueTrigger>().dialogue);
        // hide buttons
        DisableOptions();
        // show name tag
        NPCname.gameObject.SetActive(true);
        // show continue button
        cont.gameObject.SetActive(true);
        // show final text
        //finalText.gameObject.SetActive(true);
        // disable NPC box collider
        npc.GetComponent<BoxCollider2D>().enabled = false;

        //TextTrigger.Speaking = false;
    }
}

