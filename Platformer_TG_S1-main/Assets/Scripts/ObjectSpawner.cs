using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectSpawner : MonoBehaviour
{
	public GameObject platform;

	public float delay;
	float timeFromSpawn;
	public float[] spawnpoints;
	System.Random rand = new System.Random();

    void Start()
    {
		timeFromSpawn = Time.fixedTime;
    }

    void Update()
    {
		if (GameHandler.GameSpeed==4)
		{
			delay = 3;
		}
		if (GameHandler.GameSpeed == 2)
		{
			delay = 6;
		}
		if (timeFromSpawn>=delay)
		{
			Instantiate(platform, new Vector3(transform.position.x, spawnpoints[rand.Next(0, spawnpoints.Length)],transform.position.z), platform.transform.rotation);
			timeFromSpawn = 0;
		}
		timeFromSpawn += Time.deltaTime;
    }
}
