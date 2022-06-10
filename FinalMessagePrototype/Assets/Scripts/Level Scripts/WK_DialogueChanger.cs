using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WK_DialogueChanger : MonoBehaviour
{
    private static bool spoken = false;
    private static bool violent = true;
    private static int currentLoop = -1;
    private static int spokenLoop = -1;

    public GameObject speechDialogue;
    public GameObject speechManager;
    public GameObject violentDialogue;
    public GameObject violentManager;
    public GameObject niceDialogue;
    public GameObject niceManager;
    public GameObject killBox;

    // Start is called before the first frame update
    void Start()
    {
        currentLoop = LevelLoader.deathCount;
        if(spokenLoop == -1) {
            spokenLoop = 2147483647;
        }

        if(LevelLoader.Key1 == 1) {
            violent = false;
        }

        if(spoken && violent) {
            //turn off default speech
            speechDialogue.gameObject.SetActive(false);
            speechManager.gameObject.SetActive(false);
            //turn on secondary speech
            violentDialogue.gameObject.SetActive(true);
            violentManager.gameObject.SetActive(true);
            //turn off nice speech
            niceDialogue.gameObject.SetActive(false);
            niceManager.gameObject.SetActive(false);
        }
        else if(spoken && !violent) {
            //turn off default speech
            speechDialogue.gameObject.SetActive(false);
            speechManager.gameObject.SetActive(false);
            //turn off secondary speech
            violentDialogue.gameObject.SetActive(false);
            violentManager.gameObject.SetActive(false);
            //turn on nice speech
            niceDialogue.gameObject.SetActive(true);
            niceManager.gameObject.SetActive(true);
            //turn off killbox
            killBox.gameObject.SetActive(false);
        }
        else {
            if(currentLoop > spokenLoop) {
                spoken = true;
                Start();
            }
        }

        //debug stuff
        Debug.Log(currentLoop);
        Debug.Log(spoken);
        Debug.Log(spokenLoop);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    //tell code that player has spoken to the witch knight
    public void Talk() {
        spokenLoop = currentLoop;

        //debug stuff
        Debug.Log(currentLoop);
        Debug.Log(spoken);
        Debug.Log(spokenLoop);
    }
}
