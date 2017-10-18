using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public ToyPlane planeLifes;
	public float restarDelay = 5f;


	Animator anim;
	float restartTime;

	// Use this for initialization
	void Awake () {
		
		anim = GetComponent <Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (planeLifes.isAlive() == false) {
		

			anim.SetTrigger ("GameOver");


		}
		
	}
}
