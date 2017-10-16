using System;
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
        if (lifes == 3)
        {
            StartCoroutine("exchangeMaterial", material1);
        }else{
            if (lifes == 2)
            {
                StartCoroutine("exchangeMaterial", material2);
            }
            else {
                if (lifes == 1)
                {
                    StartCoroutine("exchangeMaterial", material3);
                }
            }
        }

    }

    IEnumerator exchangeMaterial(Material m)
    {
        Material currentMateral = gameObject.GetComponent<Renderer>().material;
        for (int i = 0; i < 10; i++)
        { 
            yield return new WaitForSeconds(0.1f);

            gameObject.GetComponent<Renderer>().material = currentMateral;

            yield return new WaitForSeconds(0.1f);

            gameObject.GetComponent<Renderer>().material = m;
        }
    }
}
