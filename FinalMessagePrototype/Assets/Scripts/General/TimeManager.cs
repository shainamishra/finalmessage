using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    public float startingTime = 300;
    private Text theText;
    public static bool TimesUp = false;
    

    
  

    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text>();
        TimesUp = false;
        // player = FindObjectofType<playerMovement>();
        // dog = FindObjectofType<dogMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        startingTime -= Time.deltaTime;
        float t = startingTime;
        string min = ((int) t/60).ToString();
        string sec = Mathf.Round((t%60)).ToString();

        //cosmetic changes to the time format
        if(Mathf.Round((t%60))==60) theText.text = (((int) (t/60)+1).ToString()) + ":00";
        else if(Mathf.Round((t%60))<10) theText.text = min + ":0" + sec;
        else theText.text = min + ":" + sec;

        if(startingTime<=0){
          startingTime=0;
          theText.text = min + ":0" + sec;
          TimesUp = true;
          
    
          // player.gameObject.SetActive(false);
          // dog.gameObject.SetActive(false);
        }

        if(TimesUp == true && Input.GetKeyDown("r"))
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnGUI()
    {
        if(TimesUp){
          GUI.Box(new Rect(0,0,Screen.width,Screen.height), "GAME OVER! Press 'R' to restart");
          
        }
    }
}
