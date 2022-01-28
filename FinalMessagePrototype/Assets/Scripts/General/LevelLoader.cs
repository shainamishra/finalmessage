using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // level counter var
    int level = 0;

    public Animator transition;
    public float transitionTime = 0.5f;

    public GameObject dog;
    public GameObject player;

    void Start()
    {
        dog = GameObject.Find("Dog");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(level == 0){
            // level ending conditions
            if(dog.transform.position.x > 11.5 || player.transform.position.x > 11.5){
                LoadNextLevel();
            }
        }
    }

    public void LoadNextLevel()
    {
        // loads the next scene
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        level += 1;
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
