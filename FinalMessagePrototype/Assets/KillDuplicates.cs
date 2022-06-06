using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDuplicates : MonoBehaviour
{
    static KillDuplicates instance;


    void Awake()
     {
         if(instance == null )
         {    
             instance = this; 
          
         }
         else if(instance != this)
             Destroy(this.gameObject);
     } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Awake();
        
    }
}
