using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGate : MonoBehaviour
{
    public Collider2D player;
    public Collider2D dog;
    public Collider2D button1;
    public Collider2D button2;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Collider2D>();
        dog = GameObject.Find("Dog").GetComponent<Collider2D>();
        button2 = GameObject.Find("Button2").GetComponent<Collider2D>();
        door = GameObject.Find("6DoorsDoor");
        button1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if the dog is on button1 (bottom button)
        if (button1.IsTouching(dog))
        {
            // then the button is lowered
            button1.transform.position = new Vector3(2f, -3.4f, 0.0f);
            door.SetActive(true);
           
        }
        else
        {
            // raise the button
            button1.transform.position = new Vector3(2f, -3.2f, 0.0f);
            door.SetActive(false);
            
        }

        // if the knight is on button2 (top button)
        if (button2.IsTouching(player))
        {
            // then the button is lowered
            button2.transform.position = new Vector3(21.5f, 1.4f, 0.0f);
            button1.gameObject.SetActive(true);
        }
        else
        {
            // raise the button
            button2.transform.position = new Vector3(21.5f, 1.6f, 0.0f);
        }
    }
}
