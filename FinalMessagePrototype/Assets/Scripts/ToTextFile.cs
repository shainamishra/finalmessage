using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class ToTextFile : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField finalMessage;
    public GameObject display;
    public Text displayMessage;
    public GameObject player;
    public Button finish;
    public playerMovement playerMovement;
    public dogMovement dogMovement;


    void Start()
    {
        Directory.CreateDirectory(Application.dataPath + "/YourFinalMessage/");
        playerMovement = GameObject.Find("Player").GetComponent<playerMovement>();
        dogMovement = GameObject.Find("Dog").GetComponent<dogMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // finalMessage.gameObject.SetActive(false);
        if (player.transform.position.x > 75){
            finalMessage.gameObject.SetActive(true);
        }
        if (finalMessage.text == ""){
            return;
        }
        string txtFileName = Application.dataPath + "/YourFinalMessage/" + "YourFinalMessage" + ".txt";

        if (!File.Exists(txtFileName)){
            File.WriteAllText(txtFileName, "Your Final Message: \n\n");

        }

        // if (finalMessage.gameObject.activeSelf == true){
        //     playerMovement.whileInput();
        //     dogMovement.whileInput();
        // }

        
        // if (Input.GetKeyDown(KeyCode.Return)){
        //     File.AppendAllText(txtFileName, finalMessage.text + "\n");
        //     Debug.Log(finalMessage.text);
        //     // display.SetActive(true);
        //     // displayMessage.text += " "+finalMessage.text+" ";
        //     // finalMessage.gameObject.SetActive(false);
        //     // StartCoroutine(WaitFor5Seconds());
            
        //     // SceneManager.LoadScene("25Outro");
        // }

        // if(display.activeSelf==true){
        //     SceneManager.LoadScene("25Outro");
        // }

         
        // finish.onClick.AddListener(finishInput);


        
        
    }

    public void Outro(){
        string txtFileName = Application.dataPath + "/YourFinalMessage/" + "YourFinalMessage" + ".txt";

        if (!File.Exists(txtFileName)){
            File.WriteAllText(txtFileName, "Your Final Message: \n\n");

        }

        File.AppendAllText(txtFileName, finalMessage.text + "\n");
            Debug.Log(finalMessage.text);
        SceneManager.LoadScene("25Outro");
    }
    // public IEnumerator WaitFor5Seconds()
    // {
    //     
    //     display.SetActive(true);
    //     displayMessage.text += " "+finalMessage.text+" ";
    //     // finalMessage.gameObject.SetActive(false);
    //     yield return new WaitForSecondsRealtime (3f);
    //     finalMessage.gameObject.SetActive(false);
    //     // display.SetActive(false);
    //     
        
        
        

    // }
    // void finishInput (){
    //     string txtFileName = Application.dataPath + "/YourFinalMessage/" + "YourFinalMessage" + ".txt";

    //     if (!File.Exists(txtFileName)){
    //         File.WriteAllText(txtFileName, "Your Final Message: \n\n");

    //     }

    //     File.AppendAllText(txtFileName, finalMessage.text + "\n");
    //         Debug.Log(finalMessage.text);
    //         // display.SetActive(true);
    //         // displayMessage.text += " "+finalMessage.text+" ";
    //         // finalMessage.gameObject.SetActive(false);
    //         // SceneManager.LoadScene("25Outro");

    // }
}
