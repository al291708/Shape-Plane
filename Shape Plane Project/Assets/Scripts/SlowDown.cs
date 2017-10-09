using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour {

	public GameController game;
    public ToyPlane plane;
    float time;
    float timeLife;
    
    

	// Use this for initialization
    void Update()
    {
        time -= Time.deltaTime;
        timeLife -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Slow")
        {
           
			Debug.Log ("choque");
			game.setIsSlow (false);
            

        }
        if (other.transform.tag == "Life")
        {
            if (timeLife <= 0)
            {

                Debug.Log("vida");
                plane.addLife(1);
                Debug.Log(plane.currentLifes);
                timeLife = 2f;
            }
        
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Blue")
        {

            
            Debug.Log("PUM");
            if (plane.currentLifes > 0 & plane.currentLifes <= 3)
            {
                if (time<=0)
                {
                    
                    plane.takeLife(1);
                    time = 2f;
                }
            }
           
            Debug.Log(plane.currentLifes);
            
            
            
        }

    }
  
}
