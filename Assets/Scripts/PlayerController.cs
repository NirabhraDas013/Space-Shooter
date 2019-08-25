﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject Shot;
	public Transform ShotSpawn;

	public float fireRate;
	private float nextFire;

	void Update ()
	{
		//myTime = myTime + Time.deltaTime;

		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
			gameObject.GetComponent<AudioSource> ().Play();
		}
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody> ().velocity = movement*speed;

		GetComponent<Rigidbody> ().position = new Vector3 
			(
				Mathf.Clamp(GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp(GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
			);

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody> ().velocity.x*-tilt);
	}


}