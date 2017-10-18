using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

	public ToyPlane planeLifes;
	public float restarDelay = 5f;

	public Animator animHUD;
    public Animator animPlane;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!planeLifes.isAlive()) {

            animHUD.SetTrigger ("GameOver");
		}
		
	}
}
