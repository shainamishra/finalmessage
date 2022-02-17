using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0.5f;

    public GameObject dog;
    public GameObject player;
    public GameObject door;

    public int levelVar = 0;

    void Start()
    {
        dog = GameObject.Find("Dog");
        player = GameObject.Find("Player");
        door = GameObject.Find("Door");
    }

    // Check win conditions
    void Update()
    {
        // build index starts at ZERO while out scene names start at ONE!!!!

        // start scene
        if(SceneManager.GetActiveScene().buildIndex == 0){
            // level ending conditions
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5){
                LoadNextLevel();
            }
        }

        // tutorial reasoning
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
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
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                LoadNextLevel();
            }
        }

        // tutorial knowledge
        // going to need to actually code this
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
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
            // witch knight
            if(((player.transform.position.x > -1 && player.transform.position.x < 1)) && Input.GetKeyDown("x"))
            {
                levelVar = 9;
                LoadNextLevel();
            }
            // final message 1
            else if(((player.transform.position.x > 6.5 && player.transform.position.x < 9.3) || (dog.transform.position.x > 6.5 && dog.transform.position.x < 9.3)) && Input.GetKeyDown("x"))
            {
                levelVar = 7;
                LoadNextLevel();
            }
        }

        // lonely climber
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
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
    }

    public void LoadNextLevel()
    {
        // loads the next scene
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
