﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform objetaASeguir;
	public float suavidadMovimiento;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = new Vector3 (objetaASeguir.position.x, objetaASeguir.position.y + 5f, objetaASeguir.position.z - 15);
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * suavidadMovimiento);
	}
}
