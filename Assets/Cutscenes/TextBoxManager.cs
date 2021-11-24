using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class TextBoxManager : MonoBehaviour
{
    [Header("Debug")]
    public bool verbose = false;

    public GameObject textBox;
    public TextMeshProUGUI textObj;
    public TextAsset textFile;
    public string[] textLines;
    public TextAsset nameFile;
    public string[] nameLines;

    public int currentLine;
    public int endAtLine;

    public float delay = 0.1f;
    public int charsPerDelay = 2;

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

    IEnumerator ShowText(string name, string text)
    {
        showingText = true;
        diasound.Raise();
        
        if (name.Length>1)
        {
            name = name + ": ";
            string full_line = name + text;
            textObj.SetText(full_line);
        } else
        {
            textObj.SetText(text);
        }

        int total_length = name.Length + text.Length;
        textObj.maxVisibleCharacters = name.Length;
     
        for (int i = name.Length;  i < total_length; i++)
        {
            
            int visibleCount = i % (total_length + 1);
            textObj.maxVisibleCharacters = visibleCount;
            if(i%charsPerDelay==0)
            {
                yield return new WaitForSeconds(delay);
            }
            
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
            nameLines[currentLine]= nameLines[currentLine].Replace("\r", "");
            co = StartCoroutine(ShowText(nameLines[currentLine],textLines[currentLine]));
           
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if(showingText && !Array.Exists(unskippableLines,element=>element==currentLine))
            {
                if (co != null) StopCoroutine(co);
                if (nameLines[currentLine].Length > 1)
                {
                    textObj.text = nameLines[currentLine] + ": " + textLines[currentLine];
                    textObj.maxVisibleCharacters = 999;
                }
                else
                {
                    textObj.text = textLines[currentLine];
                    textObj.maxVisibleCharacters = 999;
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
