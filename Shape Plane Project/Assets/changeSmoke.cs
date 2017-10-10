using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSmoke : MonoBehaviour {

    public Material material1;
    public Material material2;
    public Material material3;

    public ToyPlane plane;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material= material1;
	}
	
	// Update is called once per frame
	void Update () {
        if (plane.currentLifes == 3) gameObject.GetComponent<Renderer>().material = material1;
        else if (plane.currentLifes == 2) gameObject.GetComponent<Renderer>().material = material2;
        else if (plane.currentLifes == 1) gameObject.GetComponent<Renderer>().material = material3;

    }
}
