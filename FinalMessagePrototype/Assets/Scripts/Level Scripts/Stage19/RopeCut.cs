/* A simple script to make the rope an interactable object that releases the elevator.
 * It also "animates" is, by which I mean it stops rendering after a being cut.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCut : MonoBehaviour
{
    public bool status;

    // Start is called before the first frame update
    void Start()
    {
        status = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "StrikeZone")
        {
            status = true;
            Destroy(gameObject, 0.15f);
            //Debug.Log(status);
        }
    }
}