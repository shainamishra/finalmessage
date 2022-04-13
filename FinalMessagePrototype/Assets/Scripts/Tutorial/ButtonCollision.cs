using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollision : MonoBehaviour
{
    public Collider2D dog;
    public Collider2D player;
    public Collider2D dogButton;
    public Collider2D playerButton;

    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("Dog").GetComponent<Collider2D>();
        player = GameObject.Find("Player").GetComponent<Collider2D>();
        dogButton = GameObject.Find("DogButton").GetComponent<Collider2D>();
        playerButton = GameObject.Find("PlayerButton").GetComponent<Collider2D>();
        
        door = GameObject.Find("Door");
    }

    // Update is called once per frame
    void Update()
    {
        // if the dog is on the button
        if(dogButton.IsTouching(dog))
        {
            // then the button is lowered
            Vector3 temp = new Vector3(3.75f, -3f, 0.0f);
            (GameObject.Find("DogButton")).transform.position = temp;
        }
        else
        {
            // raise the button
            Vector3 temp = new Vector3(3.75f, -2.75f, 0.0f);
            (GameObject.Find("DogButton")).transform.position = temp;
        }

        // if the player is on the button then the button is lowered
        if(playerButton.IsTouching(player))
        {
            // then the button is lowered
            Vector3 temp = new Vector3(-3.75f, -3f, 0.0f);
            (GameObject.Find("PlayerButton")).transform.position = temp;
        }
        else
        {
            // raise the button
            Vector3 temp = new Vector3(-3.75f, -2.75f, 0.0f);
            (GameObject.Find("PlayerButton")).transform.position = temp;
        }

        // if the dog and the player are on their respective buttons and the door is visisble
        if (dogButton.IsTouching(dog) && playerButton.IsTouching(player) && door.activeSelf == true)
        {
            // the door disappears
            door.SetActive(false);
        }
    }
}
