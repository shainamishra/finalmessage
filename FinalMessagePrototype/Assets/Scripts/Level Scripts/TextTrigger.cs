using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextTrigger : MonoBehaviour
{
    private bool textOn = false;

    public Collider2D player; 
    public Collider2D npc; 

    public Button start; 
    public Button cont; 

    public Button option1; 
    public Button option2; 
    public Button option3; 
    public Button option4; 

    public GameObject NPCname; 
    public GameObject canvas; 
    public GameObject finalText; 

    //int correctAnswer = 0;

    // level loading stuff
    public int levelVar = 0;
    public Animator transition;
    public float transitionTime = 0.5f;

    int contClicked = 0;
    public int sentences;
    
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

        // option button listeners
        Button btn1 = option1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);

        Button btn2 = option2.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);

        Button btn3 = option3.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClick3);

        Button btn4 = option4.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClick4);
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the player touches the NPC
        if(player.IsTouching(npc) && (textOn == false))
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
        contClicked = contClicked + 1;

        if (contClicked == sentences)
        {
            //remove continue button
            //cont.GetComponent<Button>().onClick.RemoveListener(continueTask);
            cont.gameObject.SetActive(false);

            if(SceneManager.GetActiveScene().buildIndex != 17)
            {
                //hide NPC name tag
                NPCname.gameObject.SetActive(false);
                // show option buttons
                EnableOptions();
            }
        }
    }

    void TaskOnClick1()
    {
        levelVar = -4;
        LoadNextLevel();
    }
    void TaskOnClick2()
    {
        // if in scene 4
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            levelVar = -4;
            LoadNextLevel();
        }
    }
    void TaskOnClick3()
    {
        // if in scene 4
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            // hide buttona
            DiaableOptions();
            // show name tag
            NPCname.gameObject.SetActive(true);
            // show continue button
            //cont.gameObject.SetActive(true);
            // show final text
            finalText.gameObject.SetActive(true);
            // disable NPC box collider
            npc.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void TaskOnClick4()
    {
        // if in scene 4
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            levelVar = -4;
            LoadNextLevel();
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

