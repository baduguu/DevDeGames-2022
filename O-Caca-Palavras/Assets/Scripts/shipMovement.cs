using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
	public Transform player;
	public float speed = 4.0f;
	private bool touchStart = false;
	private Vector2 pointA; // pointA sera a posicao inicial onde o usuario clicou, e ali onde fica centralizado o joystick
	private Vector2 pointB; // pointB e a posicao para onde o usuario moveu o click, e essa direcao que se considera para a movimentacao da nave
	public Transform joystickBg;
	public Transform joystickTouch;

	private float bgWidth;
    private float bgHeight;

    // Start is called before the first frame update
    void Start()
    {
		pointA = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/5, Screen.height/10, Camera.main.transform.position.z));

		joystickTouch.transform.position = pointA;
		joystickBg.transform.position = pointA;
		joystickTouch.GetComponent<SpriteRenderer>().enabled = true;
		joystickBg.GetComponent<SpriteRenderer>().enabled = true;

		bgWidth = joystickBg.transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        bgHeight = joystickBg.transform.GetComponent<SpriteRenderer>().bounds.extents.y;

		
    }

    // Update is called once per frame
    void Update()
    {
	// movimenta via setas do teclado
	// moveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

	// movimenta via joystick

	if(Input.GetMouseButton(0)  && Camera.main.ScreenToWorldPoint(Input.mousePosition).x < joystickBg.transform.position.x + bgWidth*1.5
								&& Camera.main.ScreenToWorldPoint(Input.mousePosition).x > joystickBg.transform.position.x - bgWidth*1.5
								&& Camera.main.ScreenToWorldPoint(Input.mousePosition).y < joystickBg.transform.position.y + bgHeight*1.5
								&& Camera.main.ScreenToWorldPoint(Input.mousePosition).y > joystickBg.transform.position.y - bgHeight*1.5) {
		touchStart = true;
		pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
	}
	else {
		touchStart = false;
	}
    }

    private void FixedUpdate() {
	if (touchStart) {
		Vector2 offset = pointB - pointA;
		Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
		moveCharacter(direction);

		joystickTouch.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
	}
	else{
		joystickTouch.transform.position = new Vector2(pointA.x, pointA.y);
	}
    }





	void moveCharacter(Vector2 direction) {
		player.Translate(direction * speed * Time.deltaTime);
	}
}
