using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class adventurerKill : MonoBehaviour
{
    private static bool dead = false;
    private static int currentLoop = -1;
    private static int spokenLoop = -1;

    public GameObject adventurer;
    public GameObject finalMessage;
    public GameObject levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        currentLoop = levelLoader.gameObject.GetComponent<LevelLoader>().getDeathCount();
        if(spokenLoop == -1) {
            spokenLoop = 6;
        }

        if(dead) {
            adventurer.gameObject.SetActive(false);
            finalMessage.gameObject.SetActive(true);
        }
        else {
            if(currentLoop > spokenLoop) {
                dead = true;
                adventurer.gameObject.SetActive(false);
                finalMessage.gameObject.SetActive(true);
            }
        }

        //debug stuff
        Debug.Log(currentLoop);
        Debug.Log(dead);
        Debug.Log(spokenLoop);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //tell code that player has spoken to the adventurer
    public void Talk() {
        spokenLoop = currentLoop;

        //debug stuff
        Debug.Log(currentLoop);
        Debug.Log(dead);
        Debug.Log(spokenLoop);
    }
}
