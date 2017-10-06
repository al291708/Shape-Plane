using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPlane : MonoBehaviour {
	public int lifes;
	// Use this for initialization
	void Start () {
		lifes = 3;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int getLifes()
    {
        return lifes;
    }
}
