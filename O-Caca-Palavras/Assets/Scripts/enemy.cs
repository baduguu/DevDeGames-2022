using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using TMPro;

public class enemy : MonoBehaviour
{
    public TMP_Text letterText;

    public float speed = 1.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private string letter = "";

    private string chars = "AAAAAAAAAAAAAAEEEEEEEEEEEIIIIIIIIIIOOOOOOOOOOSSSSSSSSUUUUUUUMMMMMMRRRRRRTTTTTDDDDDLLLLLCCCCPPPPNNNNBBBFFGGHHVVJJQXZ";
    private Random random = new Random();

    // Start is called before the first frame update
    void Start()
    {
        char randomChar = chars[random.Next(chars.Length)];
        letter = randomChar.ToString();
        letterText.text = letter;

        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -screenBounds.y) {
	    Destroy(this.gameObject);
	    }
    }
}
