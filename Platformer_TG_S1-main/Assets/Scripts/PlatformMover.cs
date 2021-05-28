using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float speed;

    void Update()
    {
        speed = GameHandler.GameSpeed;
		transform.position += new Vector3(-speed * Time.deltaTime, 0, 0); 
    }
}
