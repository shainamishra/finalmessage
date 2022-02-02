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
        Button one = button1.GetComponent<Button>();
        one.onClick.AddListener(TaskOnClick);

        Button two = button2.GetComponent<Button>();
        two.onClick.AddListener(TaskOnClick);

        Button three = button3.GetComponent<Button>();
        three.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    public void TaskOnClick()
    {
        // EventSystem.current.currentSelectedGameObject.name finds the name of the object being selected so it'll give you the name of the button pressed
        Debug.Log("Clicked on " + EventSystem.current.currentSelectedGameObject.name);

        //if(go.name == "Choice 1")
        // {
        //     player.Die();
        // }

    }
}
