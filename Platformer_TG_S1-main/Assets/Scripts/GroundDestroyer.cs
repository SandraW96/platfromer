using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
	public GameObject ground;
   
    void Start()
    {
		Instantiate(ground, new Vector3(17.94f, -5f,-1), transform.rotation);
    }

    // Update is called once per frame
  	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag=="Ground")
		{
			Instantiate(ground, new Vector3(17.94f, -5f,-1), transform.rotation);
		}
		Destroy(collision.gameObject, 0);
	}

}
