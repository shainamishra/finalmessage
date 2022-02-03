using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public void OpenDoor()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
