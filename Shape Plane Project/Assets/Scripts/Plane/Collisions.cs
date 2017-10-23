using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {
    
    public GameObject meshPlane;
    public ToyPlane plane;
    private GameObject gameController;
    
    void Start()
    {
        plane = GetComponent<ToyPlane>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Collider[] colliders = other.gameObject.GetComponents<Collider>();

            foreach (Collider c in colliders)
            {
                c.enabled = false;
            }

            Collider[] childerColliders = other.gameObject.GetComponentsInChildren<Collider>();

            foreach (Collider c in childerColliders)
            {
                c.enabled = false;
            }

            StartCoroutine("blink");

            if (plane.getLifes() > 0 & plane.getLifes() <= 3)
            {
                plane.takeALife();
                GetComponentInChildren<changeSmoke>().updateSmoke(plane.getLifes());
            }

            gameController.GetComponent<ExtraPuntos>().restaPuntos(10);

            other.gameObject.GetComponentInChildren<wallMaterials>().changeToBadTransparent();
            other.gameObject.GetComponentInChildren<wallSounds>().playHitWallSound();

            GetComponentInChildren<ExtraPoints>().hitWall();

        }

        if (other.gameObject.tag == "CenterOfWall")
        {
            Collider[] colliders = other.gameObject.GetComponents<Collider>();

            foreach (Collider c in colliders)
            {
                c.enabled = false;
            }

            Collider[] parentColliders = other.gameObject.GetComponentsInParent<Collider>();

            foreach (Collider c in parentColliders)
            {
                c.enabled = false;
            }


            gameController.GetComponent<ExtraPuntos>().sumaPuntos(10);

            other.gameObject.transform.parent.GetComponentInChildren<wallMaterials>().changeToGoodTransparent();
            other.gameObject.transform.parent.GetComponentInChildren<wallSounds>().playPassWallSound();

            GetComponentInChildren<ExtraPoints>().takeWall();

        }

        if (other.transform.tag == "Slow")
        {
            
            other.gameObject.GetComponent<PowerUpsParticles>().showParticles();

            other.gameObject.SetActive(false);

            plane.setIsSlow(true);
        }

        if (other.transform.tag == "Life")
        {

            other.gameObject.GetComponent<PowerUpsParticles>().showParticles();

            other.gameObject.SetActive(false);

            if (plane.getLifes() < 3)
            {
                plane.addALife();
                GetComponentInChildren<changeSmoke>().updateSmoke(plane.getLifes());
            }    
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
