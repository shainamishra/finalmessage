using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FM5_Seeker : MonoBehaviour
{
    public GameObject Player;
    public Canvas FinalMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x > 4 && Player.transform.position.x < 30)
        {
            FinalMessage.gameObject.SetActive(true);
        }
        else { FinalMessage.gameObject.SetActive(false); }
    }
}
