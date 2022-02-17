using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Animator animator;
    public GameObject playeron;
    public GameObject dogon;
    public GameObject strikepoint;
    public GameObject reachzone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            strikepoint.SetActive(true);
            Act();
        }
        else 
        { 
            strikepoint.SetActive(false); 
        }
        if (Input.GetMouseButton(1) == true)
        {
            reachzone.SetActive(true);
        }
        else
        {
            reachzone.SetActive(false);
        }
    }

    void Act() 
    {
        if (playeron.activeSelf == true)
        {
            animator.SetTrigger("Strike");
        }
    }
}
