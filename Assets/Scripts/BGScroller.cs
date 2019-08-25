﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizedZ;

	private Vector3 startPosition;

	void Start()
	{
		startPosition = transform.position;
	}

	// Update is called once per frame
	void Update () 
	{
		float newPositoon = Mathf.Repeat (Time.time * scrollSpeed, tileSizedZ);
		transform.position = startPosition + Vector3.forward * newPositoon;
	}
}
