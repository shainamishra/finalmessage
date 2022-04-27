using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTransition : MonoBehaviour
{
    bool overlap;

    void OnTriggerEnter2D(Collider2D collider){
        overlap = true;
    }

    void OnTriggerExit2D(Collider2D collider){
        overlap = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        overlap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(overlap && Input.GetKeyDown(KeyCode.X)){
            Debug.Log("'X' pressed while in space");
            SceneManager.LoadScene("20AliveCheck");
        }
    }
}
