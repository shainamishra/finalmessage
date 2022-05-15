using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTransitionTrigger : MonoBehaviour
{
    public bool status;

    Collider2D thisDoor;
    Collider2D knight;
    Collider2D dog;

    // Start is called before the first frame update
    void Start()
    {
        status = false;
        knight = GameObject.Find("Player").GetComponent<Collider2D>();
        dog = GameObject.Find("Dog").GetComponent<Collider2D>();
        thisDoor = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if((thisDoor.IsTouching(knight) || thisDoor.IsTouching(dog)) && Input.GetKeyDown(KeyCode.E)){
            status = true;
        }
        else{
            status = false;
        }
    }
}
