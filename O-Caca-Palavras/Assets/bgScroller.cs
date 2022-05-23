using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-2f, 2f), transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -0.3f * Time.deltaTime);

	if (transform.position.y < -14.3f) {
		transform.position = new Vector3(Random.Range(-2f, 2f), 14.3f);
	}
    }
}
