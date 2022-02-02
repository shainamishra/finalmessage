using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public GameObject dog;
    public GameObject human;
    public GameObject ropeinteract;
    public GameObject freeNPC;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(dog.GetComponent<Collider2D>(), human.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(dog.GetComponent<Collider2D>(), ropeinteract.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(human.GetComponent<Collider2D>(), ropeinteract.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(human.GetComponent<Collider2D>(), freeNPC.GetComponent<Collider2D>());
    }
}
