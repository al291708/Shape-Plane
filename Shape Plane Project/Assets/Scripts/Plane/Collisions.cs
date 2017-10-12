using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {
    
    public GameObject meshPlane;

    public ToyPlane plane;
    
    void Start()
    {
        plane = GetComponent<ToyPlane>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Slow")
        {
            Debug.Log("Collisions Script: coje Slow");
            plane.setIsSlow(true);
        }
        if (other.transform.tag == "Life")
        {
            if(plane.getLifes() < 3)
            {
                Debug.Log("Collisions Script: coje Life");
                plane.addALife();
                GetComponent<changeSmoke>().updateSmoke(plane.getLifes());
            }    
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        Collider[] colliders = col.gameObject.GetComponents<Collider>();

        foreach (Collider c in colliders)
        {
            c.enabled = false;
        }

        if (col.transform.tag == "Wall")
        {
            Debug.Log("Collisions Script: Choqua pared");
            StartCoroutine("blink");

            if (plane.getLifes() > 0 & plane.getLifes() <= 3)
            {
                plane.takeALife();
                GetComponentInChildren<changeSmoke>().updateSmoke(plane.getLifes());
            }
            Debug.Log("current lifes: " + plane.getLifes());
        }

    }

    IEnumerator blink()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);

            meshPlane.SetActive(false);

            yield return new WaitForSeconds(0.1f);

            meshPlane.SetActive(true);
        }
    }

}
