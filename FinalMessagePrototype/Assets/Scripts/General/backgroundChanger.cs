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

    // extra cliffs
    public SpriteRenderer cliffPt2;

    // extra floors
    public SpriteRenderer floorPt2;
    public SpriteRenderer floorPt3;
    public SpriteRenderer floorPt4;
    public SpriteRenderer floorPt5;
    public SpriteRenderer floorPt6;

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.startingTime <= 60)
        {
            bg1.sprite = bg2;
            fg1.sprite = fg2;
            cliff1.sprite = cliff2;

            cliffPt2.sprite = cliff2;

            floorPt2.sprite = fg2;
            floorPt3.sprite = fg2;
            floorPt4.sprite = fg2;
            floorPt5.sprite = fg2;
            floorPt6.sprite = fg2;
        }

        if (TimeManager.startingTime <= 0)
        {
            bg1.sprite = bg3;
            fg1.sprite = fg3;
            cliff1.sprite = cliff3;

            cliffPt2.sprite = cliff3;

            floorPt2.sprite = fg3;
            floorPt3.sprite = fg3;
            floorPt4.sprite = fg3;
            floorPt5.sprite = fg3;
            floorPt6.sprite = fg3;
        }
    }
}
