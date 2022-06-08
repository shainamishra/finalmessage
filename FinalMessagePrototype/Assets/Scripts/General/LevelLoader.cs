using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class LevelLoader : MonoBehaviour
{
    public static int[] levels = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    public Animator transition;
    public float transitionTime = 0.5f;

    public GameObject dog;
    public GameObject player;
    public GameObject playeron;
    public GameObject door;
    GameObject stageExit;
    ExitTransitionTrigger exitTransition;

    public FMOD.Studio.EventInstance transitionAudio;

    public static bool Prev;

    public int levelVar = 0;
    public int levelVarNeg = 0;

    public static int Key1 = 0; //falchion
    public static int Key2 = 0; //bell
    public static int Key3 = 0; //ember heart
    public static int Key4 = 0;

    public playerMovement playerMovement;
    public dogMovement dogMovement;

    public static int deathCount = 0;
    
    // private float playbackTime = 2;

    void Start()
    {
        // transition = GameObject.Find("Crossfade").GetComponent<Animator>();
        dog = GameObject.Find("Dog");
        player = GameObject.Find("Player");
        playeron = GameObject.Find("PlayerON");
        door = GameObject.Find("Door");
        playerMovement = GameObject.Find("Player").GetComponent<playerMovement>();
        dogMovement = GameObject.Find("Dog").GetComponent<dogMovement>();


        LoadLevel(24);
        transitionAudio = RuntimeManager.CreateInstance("event:/PlayerAudio/SceneTransition");
    }

    // Check win conditions
    void Update()
    {
        // transition = GameObject.Find("Crossfade").GetComponent<Animator>();
        // dog = GameObject.Find("Dog");
        // player = GameObject.Find("Player");
        // playeron = GameObject.Find("PlayerON");
        // door = GameObject.Find("Door");
        // playerMovement = GameObject.Find("Player").GetComponent<playerMovement>();
        // dogMovement = GameObject.Find("Dog").GetComponent<dogMovement>();
        if(TimeManager.TimesUp == true)
        {
            disableMovement();
        }
        
        if (Key1 == 1 && Key2 == 1 && Key3 == 1 && Key4 == 1) 
        {
            //
        }

        // quit the game
        if (Input.GetKey(KeyCode.Escape)) {
            //Application.Quit();
        }

        // Menu
        if (SceneManager.GetActiveScene().buildIndex == 0){
            levels[0] = 1;
        }

        // CutScene
        /*
        if (SceneManager.GetActiveScene().buildIndex == 25){
            no code, head empty, only vibes
        }
        */

        // Start
        if (SceneManager.GetActiveScene().buildIndex == 1){
            // level ending conditions
            levels[1] = 1;
            if(dog.transform.position.x > 10.5 || player.transform.position.x > 10.5){
                if(levels[4] == 0)
                {
                    levelVar = 0;
                    LoadNextLevel();
                }
                else if (levels[4] == 1)
                {
                    levelVar = 20;
                    LoadNextLevel();
                }
            }
        }

        // Tutorial Reasoning
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            levels[2] = 1;
            //if(door.activeSelf == false)
            //{
                if(dog.transform.position.x > 10.5 || player.transform.position.x > 10.5)
                {
                    LoadNextLevel();
                }
            //}

            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 0;
                LoadPrevLevel();
            }
        }

        // Tutorial Item
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            levels[3] = 1;
            Key4 = 1;
            if(dog.transform.position.x > 25 || player.transform.position.x > 25)
            {
                levelVar = 0;
                LoadNextLevel();
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 0;
                LoadPrevLevel();
            }
        }

        // Tutorial Knowledge
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            levels[4] = 1;

            // four platform
            if(dog.transform.position.x > 10.5 || player.transform.position.x > 10.5)
            {
                // goes to three doors
                levelVar = 17;
                LoadNextLevel();
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 0;
                LoadPrevLevel();
            }
        }

        // Lonely Climber
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            levels[5] = 1;
            // FM 2
            //if(((player.transform.position.x > 10.5 && player.transform.position.y > 10)) || (dog.transform.position.x > 10.5 && dog.transform.position.y > 10))
            stageExit = GameObject.Find("StageExit");
            exitTransition = stageExit.GetComponent<ExitTransitionTrigger>();
            if(exitTransition.status)
            {
                levelVar = 2;
                LoadNextLevel();
            }
            // no no zone
            else if((player.transform.position.x > 10.5) || (dog.transform.position.x > 10.5))
            {
                levelVar = 0;
                LoadNextLevel();
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 18;
                LoadPrevLevel();
            }

        }

        // No No Zone
        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            levels[6] = 1;
            
            if(dog.transform.position.x > 54.5 || player.transform.position.x > 54.5)
            {
                // goes to 7
                levelVar = 0;
                LoadNextLevel();
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 0;
                LoadPrevLevel();
            }

            // check if player fell from a great height, send to start
            if((player.transform.position.y < -5) || (dog.transform.position.y < -5))
            {
                levelVar = -6;
                LoadNextLevel();
                TimeManager.startingTime = 300;
                deathCount += 1;
                //timeOutVCA.setVolume(1f);
            }
        }

        // Final Message 1
        if (SceneManager.GetActiveScene().buildIndex == 7){
            // level ending conditions
            levels[7] = 1;
            if(dog.transform.position.x > 10.5 || player.transform.position.x > 10.5)
            {
                // end of branch
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 0;
                LoadPrevLevel();
            }

            // check if player fell from a great height, send to start
            if((player.transform.position.y < -5) || (dog.transform.position.y < -5))
            {
                levelVar = -7;
                LoadNextLevel();
                TimeManager.startingTime = 300;
                deathCount += 1;
                //timeOutVCA.setVolume(1f);
            }
        }

        // Final Message 2
        if (SceneManager.GetActiveScene().buildIndex == 8){
            // level ending conditions
            levels[8] = 1;
            if(dog.transform.position.x > 10.5 || player.transform.position.x > 10.5)
            {
                // end of branch
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = -2;
                LoadPrevLevel();
            }
        }

        // Four Platform
        if(SceneManager.GetActiveScene().buildIndex == 9)
        {
            levels[9] = 1;
            // lonely climber
            /*
            if(((player.transform.position.x > -1 && player.transform.position.x < 1 && player.transform.position.y > 1)) && Input.GetKeyDown("x"))
            {
                // level 10
                levelVar = 0;
                LoadNextLevel();
            }
            // other path
            else if((player.transform.position.x > 6.5 && player.transform.position.x < 9.3 && playeron.activeSelf == true) && Input.GetKeyDown("x"))
            {
                // level 10
                levelVar = 0;
                LoadNextLevel();
            }*/
            if(dog.transform.position.x > 10.5 || player.transform.position.x > 10.5){
                levelVar = 0;
                LoadNextLevel();
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 14;
                LoadPrevLevel();
            }
        }

        // Exhausted Adventurer
        if (SceneManager.GetActiveScene().buildIndex == 10){
            // level ending conditions
            levels[10] = 1;
            if(dog.transform.position.x > 10.5 || player.transform.position.x > 10.5)
            {
                levelVar = 0;
                LoadNextLevel();
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 0;
                LoadPrevLevel();
            }
        }

        // Six Doors (Scene: 10SixDoors)
        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            levels[11] = 1;
            //stageExit = GameObject.Find("StageExit");
            ExitTransitionTrigger exitTransition1 = GameObject.Find("StageExit1").GetComponent<ExitTransitionTrigger>();
            ExitTransitionTrigger exitTransition2 = GameObject.Find("StageExit2").GetComponent<ExitTransitionTrigger>();
            ExitTransitionTrigger exitTransition3 = GameObject.Find("StageExit3").GetComponent<ExitTransitionTrigger>();
            ExitTransitionTrigger exitTransition4 = GameObject.Find("StageExit4").GetComponent<ExitTransitionTrigger>();
            ExitTransitionTrigger exitTransition5 = GameObject.Find("StageExit5").GetComponent<ExitTransitionTrigger>();
            ExitTransitionTrigger exitTransition6 = GameObject.Find("StageExit6").GetComponent<ExitTransitionTrigger>();
            // final message 4 (second door) scene 13
            if (exitTransition2.status)
            {
                levelVar = 1;
                LoadNextLevel();
            }
            // final message 5 (sixth door) scene 12
            if (exitTransition6.status)
            {
                levelVar = 0;
                LoadNextLevel();
            }
            // bad doors - 11a scene 23
            if (exitTransition1.status || exitTransition3.status || exitTransition4.status || exitTransition5.status)
            {
                // goes to 23
                levelVar = 11;
                LoadNextLevel();
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 0;
                LoadPrevLevel();
            }
        }

        // Final Message 5
        if (SceneManager.GetActiveScene().buildIndex == 12){
            // level ending conditions
            levels[12] = 1;
            if(dog.transform.position.x > 10.5 || player.transform.position.x > 10.5)
            {
                // end of branch
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 0;
                LoadPrevLevel();
            }
        }

        // FM 4
        if (SceneManager.GetActiveScene().buildIndex == 13){
            // level ending conditions
            levels[13] = 1;

            if(dog.transform.position.x > 10.5 || player.transform.position.x > 10.5)
            {
                // end of branch
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = -1;
                LoadPrevLevel();
            }
        }

        // Checks
        if(SceneManager.GetActiveScene().buildIndex == 14)
        {
            levels[14] = 1;
            if(dog.transform.position.x > 28 || player.transform.position.x > 28)
            {
                // goes to 15
                levelVar = 0;
                LoadNextLevel();
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 9;
                LoadPrevLevel();
            }
        }

        // Time Gate
        if (SceneManager.GetActiveScene().buildIndex == 15)
        {
            levels[15] = 1;
            // witch knight
            if (dog.transform.position.x > 19.5 || player.transform.position.x > 19.5)
            {
                // goes to 16
                levelVar = 0;
                LoadNextLevel();
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 0;
                LoadPrevLevel();
            }
        }

        // Trick Weight
        if (SceneManager.GetActiveScene().buildIndex == 16)
        {
            levels[16] = 1;
            // graveyard
            stageExit = GameObject.Find("StageExit");
            exitTransition = stageExit.GetComponent<ExitTransitionTrigger>();
            if (dog.transform.position.x > 13.5 || player.transform.position.x > 13.5)
            {
                // goes to 17
                levelVar = 0;
                LoadNextLevel();
            }
            // FM 3
            else if(exitTransition.status)
            {
                // goes to 18
                levelVar = 1;
                LoadNextLevel();
            }
            // move back
            else if((player.transform.position.x < -10) || (dog.transform.position.x < -10))
            {
                levelVarNeg = 0;
                LoadPrevLevel();
            }

            /*
            // check if player fell from a great height
            if (GroundCheck.dead == true) 
            {
                // goes to 0
                levelVar = -15;
                LoadNextLevel();
            }
            */
        }

        // Graveyard
        if (SceneManager.GetActiveScene().buildIndex == 17){
            // level ending conditions
            levels[17] = 1;
            if(dog.transform.position.x > 205 || player.transform.position.x > 205)
            {
                //goes to 19
                levelVar = 1;
                LoadNextLevel();
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 0;
                LoadPrevLevel();
            }
        }

        // FM 3
        if (SceneManager.GetActiveScene().buildIndex == 18){
            // level ending conditions
            levels[18] = 1;
            Key1 = 1;
            Key2 = 1;
            Key3 = 1;

            if(dog.transform.position.x > 10.5 || player.transform.position.x > 10.5)
            {
                // end of branch
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = -1;
                LoadPrevLevel();
            }
        }

        // Character Check
        if (SceneManager.GetActiveScene().buildIndex == 19){
            // level ending conditions
            levels[19] = 1;
            stageExit = GameObject.Find("StageExit");
            exitTransition = stageExit.GetComponent<ExitTransitionTrigger>();
            if(exitTransition.status)
            {
                //goes to 20
                levelVar = 0;
                LoadNextLevel();
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = -1;
                LoadPrevLevel();
            }
        }

        // Alive Check
        if (SceneManager.GetActiveScene().buildIndex == 20)
        {
            levels[20] = 1;
            // back to six doors room (sadge)
            GameObject door20 = GameObject.Find("GrandioseDoor");
            GrandioseDoorOpen exitTransition20 = door20.GetComponent<GrandioseDoorOpen>();
            if (exitTransition20.status)//if(exitTransition20.status && (player.transform.position.x > 23 && player.transform.position.x < 26) || (dog.transform.position.x > 22 && dog.transform.position.x < 26))
            {
                // player has to enter door
                //if((player.transform.position.x > 23 && player.transform.position.x < 26) || (dog.transform.position.x > 22 && dog.transform.position.x < 26))
                //{
                //goes to 21
                    //if(Input.GetKeyDown(KeyCode.E))
                    //{
                        levelVar = 0;
                        LoadNextLevel();
                    //}
                //}
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = 0;
                LoadPrevLevel();
            }
        }

        // The Summit
        if (SceneManager.GetActiveScene().buildIndex == 21)
        {
            levels[21] = 1;
            
            // if (player.transform.position.x > 35 && Input.GetKeyDown("e"))
            // {
            //     levelVar = 3;
            //     LoadNextLevel();
            // }
            // move back
            // else if((player.transform.position.x < -10) || (dog.transform.position.x < -11))
            // {
            //     levelVarNeg = 0;
            //     LoadPrevLevel();
            // }
        }

        // Three doors
        if (SceneManager.GetActiveScene().buildIndex == 22)
        {
            levels[22] = 1;
            //Debug.Log(player.transform.position.x);
            ExitTransitionTrigger exitTransition1 = GameObject.Find("StageExit1").GetComponent<ExitTransitionTrigger>();
            ExitTransitionTrigger exitTransition2 = GameObject.Find("StageExit2").GetComponent<ExitTransitionTrigger>();
            ExitTransitionTrigger exitTransition3 = GameObject.Find("StageExit3").GetComponent<ExitTransitionTrigger>();
            if (exitTransition1.status)
            {
                levelVar = -18;
                LoadNextLevel();
                Debug.Log("5");
            }
            else if (exitTransition2.status)
            {
                levelVar = -14;
                LoadNextLevel();
                Debug.Log("9");
            }
            else if (exitTransition3.status)
            {
                levelVar = -9;
                LoadNextLevel();
                Debug.Log("14");
            }
            // move back
            else if((player.transform.position.x < -10 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -11 && (dog.transform.position.y > -2 && dog.transform.position.y < 1)))
            {
                levelVarNeg = -17;
                LoadPrevLevel();
            }
        }

        // 11a bad door room "you suck"
        if (SceneManager.GetActiveScene().buildIndex == 23)
        {
            levels[23] = 1;
            if (player.transform.position.x > 45 && Input.GetKeyDown("e"))
            {
                levelVar = -13;
                LoadNextLevel();
            }
        }

        
    }
    
    public void LoadNextLevel()
    {
        // loads the next scene
            // level Var is a variable which gets added to the level number so that we can jump to the correct scene
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1 + levelVar));
        
    }

    public void LoadPrevLevel()
    {
        // loads the prev scene
            // level Var is a variable which gets added to the level number so that we can jump to the correct scene
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + (-1) + levelVarNeg));
        
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // play animation
        transition.SetTrigger("Start");

        //play scene transition audio
        if (!AudioManager.isPlaying(transitionAudio)) {
            transitionAudio.start();
        }

        // wait for x amount of seconds
        yield return new WaitForSeconds(transitionTime);

        // load scene
        SceneManager.LoadScene(levelIndex);
    }

    public void disableMovement()
    {
        playerMovement.moveSpeed = 0;
        dogMovement.moveSpeed = 0;
    }

    public int getDeathCount()
    {
        return deathCount;
    }
}