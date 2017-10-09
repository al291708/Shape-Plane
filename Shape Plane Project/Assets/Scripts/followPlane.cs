using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlane : MonoBehaviour {
    public GameObject plane;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = plane.transform.position;
        //transform.rotation = plane.transform.rotation;
	}
}
