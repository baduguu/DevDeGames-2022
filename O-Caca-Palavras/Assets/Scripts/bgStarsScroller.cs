using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgStarsScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      	transform.position = new Vector3(Random.Range(-3.3f, 3.3f), transform.position.y);  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1 * Time.deltaTime);

	if (transform.position.y < -11.5f) {
		transform.position = new Vector3(Random.Range(-3.3f, 3.3f), 11.5f);
	}
    }
}
