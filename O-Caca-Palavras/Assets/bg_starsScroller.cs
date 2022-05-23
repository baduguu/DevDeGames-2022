using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_starsScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      	transform.position = new Vector3(Random.Range(-5f, 5), transform.position.y);  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1 * Time.deltaTime);

	if (transform.position.y < -15) {
		transform.position = new Vector3(Random.Range(-5f, 5f), 15);
	}
    }
}
