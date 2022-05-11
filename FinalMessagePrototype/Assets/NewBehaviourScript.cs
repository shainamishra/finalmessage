using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour

{
    public GameObject shadow;
    public Animator shadowknight;
    // Start is called before the first frame update
    void Start()
    {
        shadow.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // shadow.SetActive(false);
        shadow.SetActive(true);
        // shadowknight.SetTrigger("Start");
        while(shadow.transform.position.x<5){
            shadow.transform.Translate(new Vector3(1.0f,0.0f,0.0f));

        }
        
    }
}
