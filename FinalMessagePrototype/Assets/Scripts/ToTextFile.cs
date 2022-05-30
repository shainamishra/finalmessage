using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ToTextFile : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField finalMessage;
    public GameObject display;
    public Text displayMessage;
    public GameObject player;

    void Start()
    {
        Directory.CreateDirectory(Application.dataPath + "/YourFinalMessage/");
        
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
        if (Input.GetKeyDown(KeyCode.Return)){
            File.AppendAllText(txtFileName, finalMessage.text + "\n");
            Debug.Log(finalMessage.text);
            display.SetActive(true);
            displayMessage.text += " "+finalMessage.text+" ";
            finalMessage.gameObject.SetActive(false);

        }

        
        
    }
}
