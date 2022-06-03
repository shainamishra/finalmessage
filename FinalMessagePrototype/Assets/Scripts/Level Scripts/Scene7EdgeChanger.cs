using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene7EdgeChanger : MonoBehaviour
{
    public SpriteRenderer cliff1;
    public Sprite cliff2;
    public Sprite cliff3;

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.startingTime <= 60)
        {
            cliff1.sprite = cliff2;
        }

        if (TimeManager.startingTime <= 0)
        {
            cliff1.sprite = cliff3;
        }
    }
}