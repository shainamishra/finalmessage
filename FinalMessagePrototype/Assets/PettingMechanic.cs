using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PettingMechanic : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.name == "Player")
        {
            dogMovement.petting = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            dogMovement.petting = false;
        }
    }
}
