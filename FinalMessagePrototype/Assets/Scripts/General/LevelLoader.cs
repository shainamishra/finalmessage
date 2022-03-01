using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static int[] levels = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    public Animator transition;
    public float transitionTime = 0.5f;

    public GameObject dog;
    public GameObject player;
    public GameObject playeron;
    public GameObject door;

    public int levelVar = 0;

    void Start()
    {
        dog = GameObject.Find("Dog");
        player = GameObject.Find("Player");
        playeron = GameObject.Find("PlayerON");
        door = GameObject.Find("Door");
    }

    // Check win conditions
    void Update()
    {
        // build index starts at ZERO while out scene names start at ONE!!!!
        // end the game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("help");
            checkLevel(SceneManager.GetActiveScene().buildIndex);
            LoadNextLevel();
        }

        // QUIT THE GAME WITH ENTER
        if (Input.GetKey(KeyCode.Return))
        {
            Application.Quit();
        }

        // start scene
        if (SceneManager.GetActiveScene().buildIndex == 0){
            // level ending conditions
            levels[0] = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5){
                LoadNextLevel();
            }
        }

        // tutorial reasoning
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            levels[1] = 1;
            if(door.activeSelf == false)
            {
                if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
                {
                    LoadNextLevel();
                }
            }
        }

        // tutorial item
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            levels[2] = 1;
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                LoadNextLevel();
            }
        }

        // tutorial knowledge
        // going to need to actually code this
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            levels[] = 3;
            // four platform
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                LoadNextLevel();
            }
            //lonely climber
        }

        // four platform
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            levels[4] = 1;
            // witch knight
            if(((player.transform.position.x > -1 && player.transform.position.x < 1 && player.transform.position.y > 1)) && Input.GetKeyDown("x"))
            {
                // level Var is a variable which gets added to the number in LoadNextLevel() so that we can jump to the correct scene
                levelVar = 9;
                LoadNextLevel();
            }
            // final message 1
            else if((player.transform.position.x > 6.5 && player.transform.position.x < 9.3 && playeron.activeSelf == true) && Input.GetKeyDown("x"))
            {
                levelVar = 7;
                LoadNextLevel();
            }
        }

        // lonely climber
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            levels[5] = 1;
            // witch knight
            if(((player.transform.position.x > 11.5 && player.transform.position.y > 10)) || (dog.transform.position.x > 11.5 && dog.transform.position.y > 10))
            {
                levelVar = 8;
                LoadNextLevel();
            }
            // level 7
            else if((player.transform.position.x < -8.5 && (player.transform.position.y > 6 && player.transform.position.y < 9)) || (dog.transform.position.x < -8.5 && (dog.transform.position.y > 6 && dog.transform.position.y < 9)))
            {
                LoadNextLevel();
            }
        }

        // time gate
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            levels[8] = 1;
            // witch knight
            if (player.transform.position.x >5.9 && player.transform.position.y > 27 && Input.GetKeyDown("x"))
            {
                levelVar = 0;
                LoadNextLevel();
            }
        }

        // six doors FIX DOOR PLACEMENTS
        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            levels[9] = 1;
            // WK (does this open with the witch knight key?? omg :skull:)
            if (player.transform.position.x > -1.1 && player.transform.position.x < 1.5 && Input.GetKeyDown("x"))
            {
                levelVar = 0;
                LoadNextLevel();
            }
            // IDK WHAT FF IS SO THIS CODE IS WRONG FOR NOW
            if (player.transform.position.x > 10 && player.transform.position.x < 12.5 && Input.GetKeyDown("x"))
            {
                levelVar = 1;
                LoadNextLevel();
            }
            // wrong doors (death's door if you will)
            if (((player.transform.position.x > -4 && player.transform.position.x < -1.35) || (player.transform.position.x > 1.75 && player.transform.position.x < 4.35)
                || (player.transform.position.x > 4.4 && player.transform.position.x < 7) || (player.transform.position.x > 7.15 && player.transform.position.x < 9.7))
                && Input.GetKeyDown("x"))
            {
                levelVar = -10;
                LoadNextLevel();
            }
        }

        // witch knight
        if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            levels[14] = 1;
            // chime gate
            if ((player.transform.position.x > 10 && player.transform.position.y > 0))
            {
                levelVar = 0;
                LoadNextLevel();
            }
            // key 1
            else if ((player.transform.position.x > 6.5 && player.transform.position.x < 9.3 && playeron.activeSelf == true) && Input.GetKeyDown("x"))
            {
                levelVar = -2;
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
        // end level is index 6
        levelVar = 0;

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
            levelVar = -1;
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
        //return levelVar;
    }
}
