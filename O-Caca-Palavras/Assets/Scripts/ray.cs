using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ray : MonoBehaviour
{
    public float speed = 20.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public float stretch = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > screenBounds.y) {
	    Destroy(this.gameObject);
	    }
        stretch += 1f;
       transform.localScale = new Vector2(transform.localScale.x, stretch);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
	    // busca a palavra atual
	    GameObject word = GameObject.FindWithTag("Word");
	    TMP_Text wordText = word.GetComponent<TMP_Text>();

	    // busca a letra acertada pelo ray
	    GameObject canvas = other.gameObject.transform.GetChild(1).gameObject;
	    GameObject letter = canvas.transform.GetChild(0).gameObject;
	    TMP_Text letterText = letter.GetComponent<TMP_Text>();
	    string letterTextStr = letterText.text;

	    // atualiza a palavra atual
	    wordText.text += $"{letterTextStr}";		


            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
