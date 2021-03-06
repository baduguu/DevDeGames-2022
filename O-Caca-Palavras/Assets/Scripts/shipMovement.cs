using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour {
    public Transform player;
    public float speed = 15.0f;

    public Transform circle;
    public Transform outerCircle;

    private Vector2 startingPoint;
    private int leftTouch = 99;

    public GameObject bulletPrefab;
    public GameObject rayPrefab;

    public AudioSource bulletSound;
    public AudioSource raySound;

    // Update is called once per frame
    void Update () {
        int i = 0;
        while(i < Input.touchCount){
            Touch t = Input.GetTouch(i);
            Vector2 touchPos = getTouchPosition(t.position);
            if(t.phase == TouchPhase.Began){
                if (t.position.x < (Screen.width / 2) && t.position.y < (Screen.height / 3)) {
                    leftTouch = t.fingerId;
                    startingPoint = touchPos;
                }
            }else if(t.phase == TouchPhase.Moved && leftTouch == t.fingerId){
                Vector2 offset = touchPos - startingPoint;
                Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

                moveCharacter(direction);

                circle.transform.position = new Vector2(outerCircle.transform.position.x + direction.x, outerCircle.transform.position.y + direction.y);

            }else if(t.phase == TouchPhase.Ended && leftTouch == t.fingerId){
                leftTouch = 99;
                circle.transform.position = new Vector2(outerCircle.transform.position.x, outerCircle.transform.position.y);
            }
            ++i;
        }

    }

    Vector2 getTouchPosition(Vector2 touchPosition){
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }

    void moveCharacter(Vector2 direction){
        player.Translate(direction * speed * Time.deltaTime);
    }

    public void shootBullet() {
        bulletSound.Play();
	    GameObject b = Instantiate(bulletPrefab) as GameObject;
	    b.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.7f, player.transform.position.z);
    }
    public void shootRay() {
        raySound.Play();
        GameObject b = Instantiate(rayPrefab) as GameObject;
	    b.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.7f, player.transform.position.z);
    }
}