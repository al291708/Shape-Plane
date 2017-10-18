using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {

	Vector3 Desplazamiento;
	Vector3 Rotacion;

	private float rotationSpeed;
	private float velocidad;

	// Use this for initialization
	void Start () {
		Desplazamiento = new Vector3 (0, 0, 0);
        
        rotationSpeed = 1.55f;
        velocidad = 0.4f;
}
	
	// Update is called once per frame
	void Update () {
		RecogerInformacion ();
	}

	void RecogerInformacion(){
		//Modificamos la posicion
		Desplazamiento = new Vector3(Input.GetAxis ("Horizontal") * velocidad + this.transform.position.x, Input.GetAxis ("Vertical") * velocidad + this.transform.position.y, 0);

		this.transform.position = Desplazamiento;

		//Modificamos la rotacion
		if (transform.rotation.z > -0.57f && transform.rotation.z < 0.57f) {
			transform.Rotate (Vector3.forward * Input.GetAxis ("Vertical1") * rotationSpeed);
		} else {
			if (transform.localRotation.z < -0.57f) {
				transform.Rotate (Vector3.forward * 1.001f);
			} else if (transform.localRotation.z > 0.57f) {
				print ("1");
				transform.Rotate (-Vector3.forward * 1.001f);
			}
		}
	

		//transform.Rotate(Vector3.forward * Input.GetAxis ("Horizontal1") * rotationSpeed);

		if (transform.rotation.x > -0.57f && transform.rotation.x < 0.57f) {
			transform.Rotate (Vector3.right * Input.GetAxis ("Horizontal1") * rotationSpeed);
		} else {
			if (transform.localRotation.x < -0.57f) {
				transform.Rotate (Vector3.right * 1.001f);
			} else if (transform.localRotation.x > 0.57f) {
				print ("1");
				transform.Rotate (-Vector3.right * 1.001f);
			}
		}
	}
}
