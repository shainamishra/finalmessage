using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehavior : MonoBehaviour
{
    public GameObject npc;
    public GameObject canvas;

    void Start()
    {
        canvas.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        canvas.SetActive(true);
        npc.GetComponent<Collider2D>().enabled = false;;
        OpenDoor();
    }

    public void OpenDoor()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
