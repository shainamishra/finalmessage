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

    void Start()
    {
        dog = GameObject.Find("Dog");
        player = GameObject.Find("Player");
        door = GameObject.Find("Door");
    }

    // Check win conditions
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0){
            // level ending conditions
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5){
                LoadNextLevel();
            }
        }

        if(SceneManager.GetActiveScene().buildIndex  == 1)
        {
            if(door.activeSelf == false)
            {
                if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
                {
                    LoadNextLevel();
                }
            }
        }

        if(SceneManager.GetActiveScene().buildIndex  == 2)
        {
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                LoadNextLevel();
            }
        }

        if(SceneManager.GetActiveScene().buildIndex  == 3)
        {
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5)
            {
                LoadNextLevel();
            }
        }
    }

    public void LoadNextLevel()
    {
        // loads the next scene
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
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
