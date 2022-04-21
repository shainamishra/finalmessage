using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static int[] levels = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    public Animator transition;
    public float transitionTime = 0.5f;

    public GameObject dog;
    public GameObject player;
    public GameObject playeron;
    public GameObject door;

    public int levelVar = 0;
    public int levelVarNeg = 0;

    public static int Key1 = 0;
    public static int Key2 = 0;
    public static int Key3 = 0;
    public static int Key4 = 0;

    void Start()
    {
        dog = GameObject.Find("Dog");
        player = GameObject.Find("Player");
        playeron = GameObject.Find("PlayerON");
        door = GameObject.Find("Door");
        LoadLevel(24);
    }

    // Check win conditions
    void Update()
    {
        if (Key1 == 1 && Key2 == 1 && Key3 == 1 && Key4 == 1) 
        {
            checkLevel(SceneManager.GetActiveScene().buildIndex);
            LoadNextLevel();
        }

        checkLevel(SceneManager.GetActiveScene().buildIndex);

        // build index starts at ZERO while our scene names start at ONE!!!!
        // quit the game
        if (Input.GetKey(KeyCode.Escape)) {
            //Debug.Log("help");
            Application.Quit();
        }

        // start menu
        if (SceneManager.GetActiveScene().buildIndex == 0){
            // level ending conditions
            levels[0] = 1;
            //LoadNextLevel();
        }

        // start scene
        if (SceneManager.GetActiveScene().buildIndex == 1){
            // level ending conditions
            levels[1] = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5){
                LoadNextLevel();
            }
        }

        // tutorial reasoning
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            levels[2] = 1;
            if(door.activeSelf == false)
            {
                if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
                {
                    LoadNextLevel();
                }
            }
        }

        // tutorial item
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            levels[3] = 1;
            Key4 = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                levelVar = 0;
                LoadNextLevel();
            }
        }

        // tutorial knowledge
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            levels[4] = 1;
            // four platform
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                // goes to three doors
                levelVar = 17;
                LoadNextLevel();
            }
        }

        // lonely climber
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            levels[5] = 1;
            // FM 2
            //if(((player.transform.position.x > 11.5 && player.transform.position.y > 10)) || (dog.transform.position.x > 11.5 && dog.transform.position.y > 10))
            if(((player.transform.position.x > 11.5)) || (dog.transform.position.x > 11.5))
            {
                levelVar = 2;
                LoadNextLevel();
            }
            // no no zone
            else if((player.transform.position.x < -8.5 && (player.transform.position.y > 6 && player.transform.position.y < 9)) || (dog.transform.position.x < -8.5 && (dog.transform.position.y > 6 && dog.transform.position.y < 9)))
            {
                levelVar = 0;
                LoadNextLevel();
            }
            // check if player fell from a great height, send to start
            if (GroundCheck.dead == true)
            {
                levelVar = -5;
                LoadNextLevel();
            }
        }

        // No No Zone
        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            levels[6] = 1;
            
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                // goes to 7
                levelVar = 0;
                LoadNextLevel();
            }
        }

        // final message 1
        if (SceneManager.GetActiveScene().buildIndex == 7){
            // level ending conditions
            levels[7] = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                // end of branch
            }
        }

        // final message 2
        if (SceneManager.GetActiveScene().buildIndex == 8){
            // level ending conditions
            levels[8] = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                // end of branch
            }
        }

        // four platform
        if(SceneManager.GetActiveScene().buildIndex == 9)
        {
            levels[9] = 1;
            // lonely climber
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
            }
        }

        // exhausted adventurer
        if (SceneManager.GetActiveScene().buildIndex == 10){
            // level ending conditions
            levels[10] = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                levelVar = 0;
                LoadNextLevel();
            }
        }

        // six doors (Scene: 10SixDoors)        FIX DOOR POSITIONS
        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            levels[11] = 1;
            // final message 4 (second door) scene 13
            if (player.transform.position.x > 4.7 && player.transform.position.x < 7.6 && Input.GetKeyDown("x"))
            {
                levelVar = 1;
                LoadNextLevel();
            }
            // final message 5 (sixth door) scene 12
            if (player.transform.position.x > 31.5 && player.transform.position.x < 34.8 && Input.GetKeyDown("x"))
            {
                levelVar = 0;
                LoadNextLevel();
            }
            // bad doors - 11a scene 23
            if (((player.transform.position.x > -1.2 && player.transform.position.x < 1.4) || (player.transform.position.x > 10.7 && player.transform.position.x < 13.5)
                || (player.transform.position.x > 19.8 && player.transform.position.x < 22.5) || (player.transform.position.x > 25.5 && player.transform.position.x < 28.8))
                && Input.GetKeyDown("x"))
            {
                // goes to 23
                levelVar = 11;
                LoadNextLevel();
            }
        }

        // final message 5
        if (SceneManager.GetActiveScene().buildIndex == 12){
            // level ending conditions
            levels[12] = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                // end of branch
            }
        }

        // FM 4
        if (SceneManager.GetActiveScene().buildIndex == 13){
            // level ending conditions
            levels[13] = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                // end of branch
            }
        }

        // checks
        if(SceneManager.GetActiveScene().buildIndex == 14)
        {
            levels[14] = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                // goes to 15
                levelVar = 0;
                LoadNextLevel();
            }
            // previous level
            else if((player.transform.position.x < -8 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -1.5 && (dog.transform.position.y > 0 && dog.transform.position.y < 1)))
            {
                //LoadPrevLevel();
            }
        }

        // time gate
        if (SceneManager.GetActiveScene().buildIndex == 15)
        {
            levels[15] = 1;
            // witch knight
            if (player.transform.position.x >5.9 && player.transform.position.y > 27 && Input.GetKeyDown("x"))
            {
                // goes to 16
                levelVar = 0;
                LoadNextLevel();
            }
            // check if player fell from a great height
            if (GroundCheck.dead == true)
            {
                // goes to 0
                levelVar = -15;
                LoadNextLevel();
            }
        }

        // trick weight
        if (SceneManager.GetActiveScene().buildIndex == 16)
        {
            levels[16] = 1;
            // graveyard
            if ((player.transform.position.x > 10 && player.transform.position.y > 0))
            {
                // goes to 17
                levelVar = 0;
                LoadNextLevel();
            }
            // FM 3
            else if ((player.transform.position.x > 6.5 && player.transform.position.x < 9.3 && playeron.activeSelf == true) && Input.GetKeyDown("x"))
            {
                // goes to 18
                levelVar = 1;
                LoadNextLevel();
            }
            // previous level
            else if((player.transform.position.x < -8 && (player.transform.position.y > -3 && player.transform.position.y < 1)) || (dog.transform.position.x < -1.5 && (dog.transform.position.y > 0 && dog.transform.position.y < 1)))
            {
                //LoadPrevLevel();
            }
            // check if player fell from a great height
            if (GroundCheck.dead == true) 
            {
                // goes to 0
                levelVar = -15;
                LoadNextLevel();
            }
        }

        // Graveyard
        if (SceneManager.GetActiveScene().buildIndex == 17){
            // level ending conditions
            levels[17] = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                //goes to 19
                levelVar = 1;
                LoadNextLevel();
            }
        }

        // FM 3
        if (SceneManager.GetActiveScene().buildIndex == 18){
            // level ending conditions
            levels[18] = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                // end of branch
            }
        }

        // Character Check
        if (SceneManager.GetActiveScene().buildIndex == 19){
            // level ending conditions
            levels[19] = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                //goes to 20
                levelVar = 0;
                LoadNextLevel();
            }
        }

        // Alive Check
        if (SceneManager.GetActiveScene().buildIndex == 20)
        {
            levels[20] = 1;
            // back to six doors room (sadge)
            if (player.transform.position.x > 48 && Input.GetKeyDown("x"))
            {
                //goes to 21
                levelVar = 0;
                LoadNextLevel();
            }
        }

        // The Summit
        if (SceneManager.GetActiveScene().buildIndex == 21)
        {
            levels[21] = 1;
            if (player.transform.position.x > 48 && Input.GetKeyDown("x"))
            {
                // end of game
            }
        }

        // Three doors
        if (SceneManager.GetActiveScene().buildIndex == 22)
        {
            levels[22] = 1;
            //Debug.Log(player.transform.position.x);

            if ((player.transform.position.x > -3 && player.transform.position.x < 1.5) && Input.GetKeyDown("x"))
            {
                levelVar = -18;
                LoadNextLevel();
                Debug.Log("5");
            }
            else if ((player.transform.position.x > 1.5 && player.transform.position.x < 3.25) && Input.GetKeyDown("x"))
            {
                levelVar = -14;
                LoadNextLevel();
                Debug.Log("9");
            }
            else if ((player.transform.position.x > 5.9 && player.transform.position.x < 7.75) && Input.GetKeyDown("x"))
            {
                levelVar = -9;
                LoadNextLevel();
                Debug.Log("14");
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
        // loads the next scene
            // level Var is a variable which gets added to the level number so that we can jump to the correct scene
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + (-1) + levelVarNeg));
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

    private void checkLevel(int level)
    {
        /*
        // end level is index 6
        levelVar = 0;

        if (level == 0){
            levelVar = 0;
        } else if (level == 1){
            levelVar = 0;
        } else if (level == 2){
            levelVar = 0;
        }  else if (level == 3){
            levelVar = 0;
        }  else if (level == 4){
            levelVar = 1;
        }  else if (level == 5){
            levelVar = 0;
        }  else if (level == 6){
            levelVar = 16;
        }  else if (level == 7){
            levelVar = -2;
        }  else if (level == 8){
            levelVar = -3;
        }  else if (level == 9){
            levelVar = -4;
        }  else if (level == 10){
            levelVar = -5;
        }  else if (level == 11){
            levelVar = -6;
        }  else if (level == 12){
            levelVar = -7;
        }  else if (level == 13){
            levelVar = -8;
        }  else if (level == 14){
            levelVar = -9;
        }  else if (level == 15){
            levelVar = -10;
        }  else if (level == 16){
            levelVar = -11;
        }  else if (level == 17){
            levelVar = -12;
        }  else if (level == 18){
            levelVar = -13;
        }  else if (level == 19){
            levelVar = -14;
        }  else if (level == 20){
            levelVar = -15;
        } 

        // backwards movement
        levelVarNeg = 0;

        /*
        if (level == 0){
            levelVar = 5;
        } else if (level == 1){
            levelVar = 4;
        } else if (level == 2){
            levelVar = 3;
        }  else if (level == 3){
            levelVar = 2;
        }  else if (level == 4){
            levelVar = 1;
        }  else if (level == 5){
            levelVar = 0;
        }  else if (level == 6){
            levelVarNeg = 0;
        }  else if (level == 7){
            levelVarNeg = -1;
        }  else if (level == 8){
            levelVarNeg = 0;
        }  else if (level == 9){
            levelVarNeg = 0;
        }  else if (level == 10){
            levelVarNeg = 0;
        }  else if (level == 11){
            levelVarNeg = -1;
        }  else if (level == 12){
            levelVarNeg = -7;
        }  else if (level == 13){
            levelVarNeg = 2;
        }  else if (level == 14){
                Debug.Log("4: " + levels[4]);
                Debug.Log("5: " + levels[5]);
            if(levels[4] == 1){
                levelVarNeg = -9;
            } else if (levels[5] == 1){
                levelVarNeg = -8;
            }
        }  else if (level == 15){
            levelVarNeg = 0;
        }  else if (level == 16){
            levelVarNeg = 0;
        }  else if (level == 17){
            levelVarNeg = 0;
        }  else if (level == 18){
            levelVarNeg = 0;
        }  else if (level == 19){
            levelVarNeg = 0;
        }  else if (level == 20){
            levelVarNeg = 0;
        } 
        */
    }
}
