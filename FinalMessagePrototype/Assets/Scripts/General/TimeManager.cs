using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    public float startingTime;
    private Text theText;
    public static bool TimesUp = false;
    public GameObject shadow;
    public playerMovement player;
    public dogMovement dog;
    public SpriteRenderer mc;
    public Sprite newBG1;

    // public Animator player;
    // public Animator dog;
    // public Animator playeron;
    // public Animator dogon;

    
  

    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text>();
        TimesUp = false;
        // Update();
        // player = FindObjectofType<playerMovement>();
        // dog = FindObjectofType<dogMovement>();

        // player = gameObject.GetComponent<Animator>();
        // dog = gameObject.GetComponent<Animator>();
        // playeron = gameObject.GetComponent<Animator>();
        // dogon = gameObject.GetComponent<Animator>();


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

        shadow.SetActive(false);
        changeBG();

        if (Input.GetKeyDown(KeyCode.R)){
          SceneManager.LoadScene("1StartScene");
          startingTime = 300;
        }

        if(startingTime<=0){
          // startingTime=0;
          // theText.text = min + ":0" + sec;
          theText.text = "0:00";
          player.moveSpeed = 0;
          dog.moveSpeed = 0;
          TimesUp = true;
          
          
          shadow.SetActive(true);

         
    
          // player.gameObject.SetActive(false);
          // dog.gameObject.SetActive(false);
        }

        if(TimesUp == true && Input.GetKeyDown(KeyCode.R)){
          // player.SetFloat("Speed", 3);
          // dog.SetFloat("Speed", 3);
          // playeron.SetFloat("Speed", 3);
          // dogon.SetFloat("Speed", 3);
          TimesUp = false;
          startingTime = 300;
          SceneManager.LoadScene("1StartScene");

          // GUI.Box(new Rect(0,0,Screen.width,Screen.height), "GAME OVER! Press 'R' to restart");
          // GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
          // myButtonStyle.fontSize = 50;
          // // Load and set Font
          // Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
          // myButtonStyle.font = myFont;
          // // Set color for selected and unselected buttons
          // myButtonStyle.normal.textColor = Color.blue;
          // myButtonStyle.hover.textColor = Color.red;
          // // use style in button
          // bool testButtonTwo = GUI.Button(new Rect(0,0,Screen.width,Screen.height), "GAME OVER! Press 'R' to restart", myButtonStyle);
          // TimesUp = false;
          // startingTime = 300;
          // SceneManager.LoadScene("1StartScene");

        }

        

          
    }

    void changeBG(){
      if (startingTime <= 10){
        mc.sprite = newBG1;
      }
    }

    // void OnGUI()
    // {
    //     // if(TimesUp){

    //     //   // GUI.Box(new Rect(0,0,Screen.width,Screen.height), "GAME OVER! Press 'R' to restart");
    //     //   GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
    //     //   myButtonStyle.fontSize = 50;
    //     //   // Load and set Font
    //     //   Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
    //     //   myButtonStyle.font = myFont;
    //     //   // Set color for selected and unselected buttons
    //     //   myButtonStyle.normal.textColor = Color.blue;
    //     //   myButtonStyle.hover.textColor = Color.red;
    //     //   // use style in button
    //     //   bool testButtonTwo = GUI.Button(new Rect(0,0,Screen.width,Screen.height), "GAME OVER! Press 'R' to restart", myButtonStyle);
    //     // }
    // }

    public void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
