using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public Collider2D one;
    public Collider2D two;
    public Collider2D rock;

    public Vector3 max = new Vector3(-1.86f, 4f, 0.0f);
    public Vector3 min = new Vector3(-1.86f, -3.34f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the dog is on the button
        if(one.IsTouching(rock))
        {
            // original position
            Debug.Log("hit");
            //Vector3 temp = new Vector3(-1.86f, -3.34f, 0.0f);
            //one.transform.position = one.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        }
        else
        {
            // then the platform is raised
            Vector3 temp = one.transform.position + new Vector3(0.0f, 0.01f, 0.0f);
            Vector3 temp2 = two.transform.position - new Vector3(0.0f, 0.01f, 0.0f);
            if(temp.y < max.y){
                one.transform.position = temp;
            }
            if(temp2.y > 4){
                two.transform.position = temp2;
            }
        }
    }
}
