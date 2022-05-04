using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundChanger : MonoBehaviour
{
    public SpriteRenderer bg1;
    public Sprite bg2;
    public Sprite bg3;

    public SpriteRenderer fg1;
    public Sprite fg2;
    public Sprite fg3;

    public SpriteRenderer cliff1;
    public Sprite cliff2;
    public Sprite cliff3;

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.startingTime <= 60)
        {
            bg1.sprite = bg2;
            fg1.sprite = fg2;
            cliff1.sprite = cliff2;
        }

        if (TimeManager.startingTime <= 0)
        {
            bg1.sprite = bg3;
            fg1.sprite = fg3;
            cliff1.sprite = cliff3;
        }
    }
}
