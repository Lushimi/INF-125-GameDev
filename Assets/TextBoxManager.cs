using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextBoxManager : MonoBehaviour
{
    [Header("Debug")]
    public bool verbose = false;

    public GameObject textBox;
    public Text textObj;
    public TextAsset textFile;
    public string[] textLines;
    public TextAsset nameFile;
    public string[] nameLines;

    public int currentLine;
    public int endAtLine;

    public float delay = 0.025f;
    

    public GameEvent textAdvanced;
    public GameEvent diasound;
    public GameEvent diasoundOver;
    private bool showingText = false;
    private int lastShownLine = -1;
    public int[] unskippableLines = { 3 };
    private Coroutine co;
    // Start is called before the first frame update
    void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
            if(endAtLine==0) endAtLine = textLines.Length - 1;
        } else
        {
            if (verbose) Debug.Log("Text file missing");
        }
        if (nameFile != null)
        {
            nameLines = (nameFile.text.Split('\n'));
        }
        else
        {
            if (verbose) Debug.Log("Name file missing");
        }
    }

    IEnumerator ShowText(string fullText)
    {
        showingText = true;
        diasound.Raise();
        string currentText;
        for(int i=0;i<fullText.Length;i++)
        {
            textObj.text = textObj.text + fullText[i];
            yield return new WaitForSeconds(delay);
        }
        diasoundOver.Raise();
        showingText = false;
    }

    void Update()
    {
        if (currentLine > endAtLine)
        {
            textBox.SetActive(false);
            textObj.text = "";
        }
        else if(!showingText && lastShownLine!=currentLine)
        {
            lastShownLine = currentLine;
            if(nameLines[currentLine].Length>1)
            {
                textObj.text = nameLines[currentLine]+": ";
            } else
            {
                textObj.text = "";
            }
            co = StartCoroutine(ShowText(textLines[currentLine]));
           
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if(showingText && !Array.Exists(unskippableLines,element=>element==currentLine))
            {
                if (co != null) StopCoroutine(co);
                if (nameLines[currentLine].Length > 1)
                {
                    textObj.text = nameLines[currentLine] + ": " + textLines[currentLine];
                }
                else
                {
                    textObj.text = textLines[currentLine];
                }
                
                diasoundOver.Raise();
                showingText = false;
            } else if(!showingText)
            {
                currentLine += 1;
                textAdvanced.Raise();
            }
            
        }
        
    }
}
