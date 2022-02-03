using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{
    public GameObject dog;
    public GameObject human;
    public GameObject object1;
    public GameObject object2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(dog.GetComponent<Collider2D>(), human.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(dog.GetComponent<Collider2D>(), object1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(dog.GetComponent<Collider2D>(), object2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(human.GetComponent<Collider2D>(), object1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(human.GetComponent<Collider2D>(), object2.GetComponent<Collider2D>());
    }
}
