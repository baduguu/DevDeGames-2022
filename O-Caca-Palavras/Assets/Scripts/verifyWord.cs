using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class verifyWord : MonoBehaviour
{
    public TMP_Text wordText;
    private string lastValue;

    // Start is called before the first frame update
    void Start()
    {
        lastValue = wordText.text.ToLower();
    }

    // Update is called once per frame
    void Update()
    {
        string wordTextStr = wordText.text.ToLower();
 	bool wordExists = false;

	if (wordTextStr != lastValue) {
	   foreach (string line in System.IO.File.ReadAllLines("./Assets/Scripts/palavras.txt")) {
		string fixedLine = line;
		if (line.Length >= wordTextStr.Length) {
		    fixedLine = line.Substring(0, wordTextStr.Length);
		};

		if(fixedLine.Contains(wordTextStr)) {
        	wordText.color = Color.blue;
		    wordExists = true;
		}
		if(line == wordTextStr){
			wordText.color = Color.green;
		    wordExists = true;
		    break;
		}
	   } 

	   if (!wordExists) {
	        wordText.color = Color.red;
	   };

	   lastValue = wordTextStr;
	}
    }
}
