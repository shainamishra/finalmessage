using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextTrigger : MonoBehaviour
{
    private bool textOn = false;
    public static bool Speaking = false;

    public Collider2D player; 
    public Collider2D npc; 

    public Button start; 
    public Button cont; 
    public Button close; 

    public Button option1; 
    public Button option2; 
    public Button option3; 
    public Button option4; 

    public GameObject NPCname; 
    public GameObject canvas; 
    public GameObject finalText;
    public GameObject text;

    public GameObject dialogueManager;

    //int correctAnswer = 0;

    // level loading stuff
    public int levelVar = 0;
    public Animator transition;
    public float transitionTime = 0.5f;

    int contClicked = 0;
    public int sentences;

    //toggling for conversations or Final Messages
    public bool finalMessage = false;
    //toggling for if the dialogue can be reread in full
    public bool repeatable = false;
    
    void Start()
    {
        // hide text
        DisableCanvas();

        // hide start button
        start.gameObject.SetActive(false);

        // start button listeners
        Button startBTN = start.GetComponent<Button>();
        startBTN.onClick.AddListener(startTask);

        // continue button listeners
        Button continueBTN = cont.GetComponent<Button>();
        continueBTN.onClick.AddListener(continueTask);

        // close button listeners
        Button closeBTN = close.GetComponent<Button>();
        closeBTN.onClick.AddListener(Close);

        // option button listeners
        Button btn1 = option1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);

        Button btn2 = option2.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);

        Button btn3 = option3.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClick3);

        Button btn4 = option4.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClick4);
        
        //adjust sentences to correct value
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
    void Close() 
    {
        if(repeatable) {
            contClicked = 0;
        }
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
    void DisableOptions() 
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
        
        //reveal continue button if there is more text
        if(!finalMessage || contClicked < sentences) {
            cont.gameObject.SetActive(true);
        }
        else {//remove continue button
            cont.gameObject.SetActive(false);
        }

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

            // if the dialogue isn't for a final message
            if(!finalMessage)
            {
                //hide NPC name tag
                NPCname.gameObject.SetActive(false);
                // show option buttons
                EnableOptions();
            }
            // if(SceneManager.GetActiveScene().buildIndex == 3 && finalMessage)
            // {
            //     text = GameObject.Find("Start Text");
            //     text.gameObject.SetActive(false);
            //     finalText.gameObject.SetActive(true);
            // }
        }
        else
        {
            //reveal continue button
            cont.gameObject.SetActive(true);
            contClicked = contClicked + 1;
        }
    }

    void TaskOnClick1()
    {
        // if in scene 4
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            levelVar = -4;
            LoadNextLevel();
        }
        // not in scene 4
        else {
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
    }
    void TaskOnClick2()
    {
        // if in scene 4
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            levelVar = -4;
            LoadNextLevel();
        }
        // not in scene 4
        else {
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
    }
    void TaskOnClick3()
    {
        // if in scene 4
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            // hide buttons
            DisableOptions();
            // show name tag
            NPCname.gameObject.SetActive(true);
            // show continue button
            //cont.gameObject.SetActive(true);
            // show final text
            finalText.gameObject.SetActive(true);
            // disable NPC box collider
            npc.GetComponent<BoxCollider2D>().enabled = false;

            TextTrigger.Speaking = false;
        }
        // not in scene 4
        else {
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
    }
    void TaskOnClick4()
    {
        // if in scene 4
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            levelVar = -4;
            LoadNextLevel();
        }
        // not in scene 4
        else {
            // hide buttons
            DisableOptions();
            // show name tag
            NPCname.gameObject.SetActive(true);
            // show continue button
            //cont.gameObject.SetActive(true);
            // show final text
            finalText.gameObject.SetActive(true);
            // disable NPC box collider
            npc.GetComponent<BoxCollider2D>().enabled = false;

            TextTrigger.Speaking = false;
        }
    }

    void LoadNextLevel()
    {
        // loads the next scene
            // level Var is a variable which gets added to the level number so that we can jump to the correct scene
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1 + levelVar));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // play animation
        transition.SetTrigger("Start");

        // wait for x amount of seconds
        yield return new WaitForSeconds(transitionTime);

        // load scene
        SceneManager.LoadScene(levelIndex);
    }
}

