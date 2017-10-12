using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSmoke : MonoBehaviour {

    public Material material1;
    public Material material2;
    public Material material3;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material= material1;
	}
	
	// Update is called once per frame
	public void updateSmoke (int lifes) {
        if (lifes == 3) gameObject.GetComponent<Renderer>().material = material1;
        else if (lifes == 2) gameObject.GetComponent<Renderer>().material = material2;
        else if (lifes == 1) gameObject.GetComponent<Renderer>().material = material3;

    }
}
