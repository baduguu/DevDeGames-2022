using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitShipArea : MonoBehaviour
{
	public Transform player;

    // Update is called once per frame
    void Update()
    {
	player.position = new Vector3(Mathf.Clamp(player.position.x, -4.7f, 4.7f), Mathf.Clamp(player.position.y, -4f, -2.25f));
    }
}
