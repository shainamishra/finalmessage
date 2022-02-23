using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAction : MonoBehaviour
{
    public Animator animator;
    public GameObject dogon;
    //public GameObject barkpoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dogon.activeSelf == true)
        {
            if (Input.GetMouseButton(0) == true)
            {
                //barkpoint.SetActive(true);
                Act();
            }
            else
            {
                //barkpoint.SetActive(false);
            }
        }
    }

    void Act()
    {
        animator.SetTrigger("Bark");
    }
}
