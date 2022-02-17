using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public Collider2D one;
    public Collider2D two;
    public Collider2D rock;
    public Collider2D rock2;

    public Vector3 max = new Vector3(-1.86f, 4f, 0.0f);
    public Vector3 min = new Vector3(-1.86f, -3.34f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rock2POS = rock2.transform.position;
        
        // if the rock is on the button
        if(one.IsTouching(rock))
        {
            //Debug.Log("first");
        }
        else if ((!one.IsTouching(rock)) && (!one.IsTouching(rock2)) && (rock2POS.y > 10))
        {
            // Debug.Log("kdjfjkhadhk");

            // then the platforms move
            Vector3 temp = one.transform.position + new Vector3(0.0f, 0.01f, 0.0f);
            Vector3 temp2 = two.transform.position - new Vector3(0.0f, 0.01f, 0.0f);

            // to the new position
            if(temp.y < max.y){
                one.transform.position = temp;
            }
            if(temp2.y > 4){
                two.transform.position = temp2;
            }
        }
        // if the rock is on the button
        else if (one.IsTouching(rock2))
        {
            // original position
            //Debug.Log("second");
            
            // then the platforms move
            Vector3 temp = one.transform.position - new Vector3(0.0f, 0.01f, 0.0f);
            Vector3 temp2 = two.transform.position + new Vector3(0.0f, 0.01f, 0.0f);
            
            // to the original position
            if(temp.y > min.y){
                one.transform.position = temp;
            }
            if(temp2.y < 11.9){
                two.transform.position = temp2;
            }
        }
    }
}
