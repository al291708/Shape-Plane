using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float size = Random.Range (2.5f, 4.5f);
		this.transform.localScale = new Vector3 (size, size, size);
		Invoke ("Eliminar", 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Eliminar (){
		Destroy (this);
	}
}
