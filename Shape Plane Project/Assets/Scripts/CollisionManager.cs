using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

    public GameController game;
    public ToyPlane plane;


    // Use this for initialization

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Slow")
        {

            Debug.Log("choque");
            game.setIsSlow(false);


        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Blue")
        {
            Debug.Log("PUM");
          
            Debug.Log(plane.getLifes());
            




        }

    }
}
