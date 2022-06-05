using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableGlow : MonoBehaviour
{
    Vector3 scale;
    bool is_glowing_out;
    public float rate = 0.0025f;

    // Start is called before the first frame update
    void Start()
    {
        is_glowing_out = true;
    }

    // Update is called once per frame
    void Update()
    {
        scale = transform.localScale;
        if(is_glowing_out){
            if(scale.x < 3){
                scale += new Vector3(rate, rate, rate);
            }
            else{
                is_glowing_out = false;
            }
        }
        else{
            if(scale.x > 2){
                scale -= new Vector3(rate, rate, rate);
            }
            else{
                is_glowing_out = true;
            }
        }
        transform.localScale = scale;
    }
}
