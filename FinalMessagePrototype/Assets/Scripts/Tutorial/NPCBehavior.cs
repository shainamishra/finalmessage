using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    public void Talk()
    {
        panel.SetActive(true);
    }

    public void OpenDoor()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
