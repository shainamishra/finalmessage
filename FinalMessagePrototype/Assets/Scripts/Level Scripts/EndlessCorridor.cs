using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessCorridor : MonoBehaviour
{
    public GameObject player;
    public GameObject loopTrigger;
    public bool looped = false;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        loopTrigger = GameObject.Find("LoopOnce");
        door.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LoopOnce" && looped == false)
        {
            player.transform.position = new Vector3(-8.3f, -1.2f, 0.0f);
            looped = true;
            loopTrigger.SetActive(false);
            door.SetActive(true);
        }
    }
}
