using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBehaviour : MonoBehaviour
{

    public Button button1;
    public Button button2;
    public Button button3;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        //NPC = GameObject.FindWithTag("NPC");
        //button = button.GetComponent<Button>();
        button1.onClick.AddListener(TaskOnClick);
        button2.onClick.AddListener(TaskOnClick);
        button3.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    public void TaskOnClick()
    {
        //Debug.Log("i am at task on click");
        Debug.Log("Clicked on ");

        // if(go.name == "Choice 1")
        // {
        //     player.Die();
        // }

    }
}
