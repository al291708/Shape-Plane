using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnimation : MonoBehaviour {

    public ToyPlane plane;
    public Animator animacion;

    public GameObject explosionParticula;


    public void Update()
    {
        if(GetComponent<ToyPlane>().getLifes() <= 0)
        {
            gameOver();
        }

    }

    public void gameOver()
    {
        Enderezar();

        Invoke("CrearExplosion", 0);
        Invoke("CrearExplosion", 0.5f);
        Invoke("CrearExplosion", 1.3f);
        Invoke("CrearExplosion", 1.8f);

        animacion.SetBool("GameOver", true);
    }

    void Enderezar()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, -90, 0)), 0.15f);
    }

    void CrearExplosion()
    {
        Instantiate(explosionParticula, this.transform.position, this.transform.rotation, this.transform);
    }
}
