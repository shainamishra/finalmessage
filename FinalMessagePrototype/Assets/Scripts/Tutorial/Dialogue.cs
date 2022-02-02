using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Button button1;
    public Button button2;
    public Button button3;
    public string[] lines;
    public float textSpeed;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        // UnityEngine.UI.Button button1 = GameObject.Find("Choice1").GetComponent<UnityEngine.UI.Button>();
        // UnityEngine.UI.Button button2 = GameObject.Find("Choice2").GetComponent<UnityEngine.UI.Button>();
        // UnityEngine.UI.Button button3 = GameObject.Find("Choice3").GetComponent<UnityEngine.UI.Button>();
        //Debug.Log("i am at dialogue start function!");
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          if (textComponent.text == lines[index])
          {
            NextLine();
          }
          else
          {
            StopAllCoroutines();
            textComponent.text = lines[index];
          }
        }
    }

    void StartDialogue()
    {
      index = 0;
      StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length-1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        //exception for these buttons
        if (index == lines.Length-1)
        {
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(true);
            button3.gameObject.SetActive(true);
        }
        else
        {
          gameObject.SetActive(false);
        }
    }
}
