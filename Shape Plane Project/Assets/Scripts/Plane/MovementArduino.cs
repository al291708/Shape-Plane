using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class MovementArduino : MonoBehaviour {
    

    // Use this for initialization
    void Start()
    {
        string[] portNames = SerialPort.GetPortNames();

        if (portNames.Length >= 2)
        {
            /*_streamMove = new SerialPort(portNames[portNames.Length - 2], 9600);
            _streamRotate = new SerialPort(portNames[portNames.Length - 1], 9600);
                       _readValueMove = "";
            _readValueRotate = "";


            _streamMove.Open();
            _streamRotate.Open();*/


            StartCoroutine("move", 0.05f);
            StartCoroutine("rotate", 0.05f);
            
        }



    }

    IEnumerator move(float time)
    {
        yield return new WaitForSeconds(time);

        while (GetComponent<ToyPlane>().getLifes() > 0)
        {
            yield return new WaitForSeconds(time);
            if (!GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseMenuScript>().isGamePaused())
            {
                transform.position = GetComponent<ArduinoThreadMovoment>().getPosition();
            }

        }

        Debug.Log("Cierre puerto movimiento");
        GetComponent<ArduinoThreadMovoment>().closeMovePort();
        GetComponent<Die>().die();

    }

    IEnumerator rotate(float time)
    {
        yield return new WaitForSeconds(time);
        
        while (GetComponent<ToyPlane>().getLifes() > 0)
        {
            yield return new WaitForSeconds(time);

            if (!GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseMenuScript>().isGamePaused())
            {
                transform.eulerAngles = GetComponent<ArduinoThreadMovoment>().getAngle();
            }
        }

        Debug.Log("Cierre puerto rotacion");
        GetComponent<ArduinoThreadMovoment>().closeRotatePort();


    }
}
