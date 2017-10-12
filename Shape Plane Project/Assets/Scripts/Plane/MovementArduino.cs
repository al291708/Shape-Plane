using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class MovementArduino : MonoBehaviour {
    private SerialPort _streamMove; // Objeto de la clase SerialPort
    private SerialPort _streamRotate; // Objeto de la clase SerialPort

    private string _readValueMove; // Variable para guardar lo que se lea del puerto serie
    private string _readValueRotate; // Variable para guardar lo que se lea del puerto serie


    // Use this for initialization
    void Start()
    {
        string[] portNames = SerialPort.GetPortNames();

        /*foreach (string s in portNames)
        {
            Debug.Log(s);
        }*/

        _streamMove = new SerialPort(portNames[portNames.Length - 2], 9600);
        _streamRotate = new SerialPort(portNames[portNames.Length - 1], 9600);

        _readValueMove = "";
        _readValueRotate = "";


        _streamMove.Open();
        _streamRotate.Open();
        

        StartCoroutine("move", 0.05f);
        StartCoroutine("rotate", 0.05f);

    }

    IEnumerator move(float time)
    {
        yield return new WaitForSeconds(time);

        while (GetComponent<ToyPlane>().getLifes() > 0)
        {
            yield return new WaitForSeconds(time);

            _readValueMove = _streamMove.ReadLine();
            mueve(_readValueMove);

        }

        Debug.Log("Cierre puerto movimiento");
        _streamMove.Close();

    }

    IEnumerator rotate(float time)
    {
        yield return new WaitForSeconds(time);
        
        while (GetComponent<ToyPlane>().getLifes() > 0)
        {
            yield return new WaitForSeconds(time);

            _readValueRotate = _streamRotate.ReadLine();
            rota(_readValueRotate);

        }

        Debug.Log("Cierre puerto rotacion");
        _streamRotate.Close();

    }

    void rota(string _readValue)
    {
        if (!GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseMenuScript>().isGamePaused())
        {
            string[] values = _readValue.Split('/');


            if (values[2] != "-1")
            {
                transform.eulerAngles = new Vector3(float.Parse(values[4]), -90f, -1 * float.Parse(values[3]));
            }
        }

    }

    void mueve(string _readValue)
    {
        if (!GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseMenuScript>().isGamePaused())
        {
            string[] values = _readValue.Split('/');


            if (values[2] != "-1")
            {
                transform.position = new Vector3(float.Parse(values[4]) * -0.2f, -1 * float.Parse(values[3]) * 0.1f, 0);
            }
        }
    }

}
