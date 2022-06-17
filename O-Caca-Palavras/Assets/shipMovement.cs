using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
	public Transform player;
	public float speed = 4.0f;
	private bool touchStart = false;
	private Vector2 pointA; // pointA será a posição inicial onde o usuario clicou, é ali onde fica centralizado o joystick
	private Vector2 pointB; // pointB é a posição para onde o usuario moveu o click, é essa direção que se considera para a movimentação da nave
	public Transform joystickBg;
	public Transform joystickTouch;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
	// movimenta via setas do teclado
	// moveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));



	// movimenta via joystick
	if (Input.GetMouseButtonDown(0)) {
		pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

		joystickTouch.transform.position = pointA;
		joystickBg.transform.position = pointA;
		joystickTouch.GetComponent<SpriteRenderer>().enabled = true;
		joystickBg.GetComponent<SpriteRenderer>().enabled = true;
	}

	if(Input.GetMouseButton(0)) {
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
		moveCharacter(direction * 1);

		joystickTouch.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
	}
	else {	// remove o joystick se nao estiver sendo usado
		joystickTouch.GetComponent<SpriteRenderer>().enabled = false;
		joystickBg.GetComponent<SpriteRenderer>().enabled = false;
	}
    }





	void moveCharacter(Vector2 direction) {
		player.Translate(direction * speed * Time.deltaTime);
	}
}
