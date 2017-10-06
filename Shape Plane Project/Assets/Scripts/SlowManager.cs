using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowManager : MonoBehaviour {

	// Use this for initialization
	float slowTime;
	public GameController game;
	void Start () {
		slowTime = 10f;

		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (game.getIsSlow() == false) {
			slowTime -= Time.deltaTime;
			if(slowTime<0){
				game.setIsSlow (true);
                slowTime = 10f;
		}
			
	}
}
}
