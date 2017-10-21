using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour {

	//public GameController game;
    public ToyPlane plane;
	public Animator animacion;
	float time;
    float timeLife;
    
	public GameObject explosionParticula;

	// Use this for initialization
    void Update()
    {
		if (plane.gameObject.GetComponent<ToyPlane>().getLifes() <= 0) {
            GameOver();
		}
    }
  	
	void CrearExplosion (){
		//Instantiate (explosionParticula, this.transform.position, this.transform.rotation, this.transform);
	}

	void GameOver () {
		//vivo = false;

		Enderezar ();

		Invoke ("CrearExplosion", 0);
		Invoke ("CrearExplosion", 0.5f);
		Invoke ("CrearExplosion", 1.3f);
		Invoke ("CrearExplosion", 1.8f);

		//this.gameObject.GetComponent <PlaneMovement> ().enabled = false;
        //  this.gameObject.GetComponent<MovementArduino>().enabled = false;

		animacion.SetBool ("GameOver", true);
	}

	void Enderezar (){
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (new Vector3 (0, -90, 0)), 0.15f);
	}
}
