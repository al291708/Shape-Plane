using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraPuntos : MonoBehaviour {
    int puntuacion;
    private GameObject plane;
    public Text textoPuntuacion;

    // Use this for initialization
    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("Player");

        puntuacion = 0;

        StartCoroutine("constantPoints");
    }

    IEnumerator constantPoints()
    {
        yield return new WaitForSeconds(0.1f);
        //Debug.Log(plane.GetComponent<ToyPlane>().getLifes());
        while (plane.GetComponent<ToyPlane>().isAlive() && !GetComponent<PauseMenuScript>().isGamePaused())
        {
            puntuacion += 1;
            ActualizarMarcador();

            yield return new WaitForSeconds(0.5f);
        }
    }

    void ActualizarMarcador()
    {
        textoPuntuacion.text = "Points: " + puntuacion.ToString();
    }

    public void restaPuntos(int points)
    {
        puntuacion -= points;

        if(puntuacion < 0)
        {
            puntuacion = 0;
        }

        ActualizarMarcador();
    }

    public void sumaPuntos(int points)
    {
        puntuacion += points;

        ActualizarMarcador();
    }
}
