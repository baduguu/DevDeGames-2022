using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using TMPro;

public class randomLetter : MonoBehaviour
{
    public TMP_Text letterText;
    private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private Random random = new Random();


    // Start is called before the first frame update
    void Start()
    {
        char randomChar = chars[random.Next(chars.Length)];
        letterText.text = randomChar.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

