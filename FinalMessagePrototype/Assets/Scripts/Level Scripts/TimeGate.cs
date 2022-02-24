using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGate : MonoBehaviour
{
    public Collider2D dog;
    public Collider2D button1;
    public GameObject blocked;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("Dog").GetComponent<Collider2D>();
        button1 = GameObject.Find("Button1").GetComponent<Collider2D>();
        blocked = GameObject.Find("InvisibleBarrier");
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is on the button1
        if (button1.IsTouching(dog))
        {
            // then the button is lowered
            //Vector3 temp1 = new Vector3(8.39f, -4.4f, 0.0f);
            button1.transform.position = new Vector3(10.57f, -3.4f, 0.0f);
            blocked.SetActive(false);
        }
        else
        {
            // raise the button
            //Vector3 temp1 = new Vector3(-5.1f, -4.2f, 0.0f);
            button1.transform.position = new Vector3(10.57f, -3.2f, 0.0f);
            blocked.SetActive(true);
        }
    }
}
