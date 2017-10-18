using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class ArduinoThreadMovoment : MonoBehaviour {

    private SerialPort _streamMove; // Objeto de la clase SerialPort
    private SerialPort _streamRotate; // Objeto de la clase SerialPort

    private Thread threadMove = null;
    private Thread threadRotate = null;

    private Vector3 position;
    private Vector3 angle;

    private string[] portNames;
    

    // Use this for initialization
    void Start ()
    {
        portNames = SerialPort.GetPortNames();

        foreach(string pn in portNames)
        {
            Debug.Log(pn);

        }

        if (portNames.Length >= 2)
        {
            threadMove = new Thread(GetArduinoMove);
            threadMove.Start();

            threadRotate = new Thread(GetArduinoRotate);
            threadRotate.Start();
        }
    }

    void Update()
    {
        if (portNames.Length >= 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("CIERRE PUERTOS");
                _streamMove.Close();
                threadMove.Abort();
                _streamRotate.Close();
                threadRotate.Abort();
            }
        }
    }

    private void GetArduinoMove()
    {
        _streamMove = new SerialPort(portNames[portNames.Length - 2], 9600);
        _streamMove.Open();

        while (threadMove.IsAlive)
        {
            Debug.Log("lee");

            string _readValueMove = _streamMove.ReadLine();

            mueve(_readValueMove);
        }
    }

    private void GetArduinoRotate()
    {
        _streamRotate = new SerialPort(portNames[portNames.Length - 1], 9600);
        _streamRotate.Open();

        while (threadRotate.IsAlive)
        {
            string _readValueRotate = _streamRotate.ReadLine();

            rotate(_readValueRotate);
        }
    }

    void mueve(string _readValue)
    {
        string[] values = _readValue.Split('/');
        
        if (values[2] != "-1")
        {
            position = new Vector3(float.Parse(values[4]) * -0.2f, -1 * float.Parse(values[3]) * 0.1f, 0);
            //Debug.Log(position);


        }
    }


    void rotate(string _readValue)
    {
        string[] values = _readValue.Split('/');


        if (values[2] != "-1")
        {
            angle = new Vector3(float.Parse(values[4]), -90f, -1 * float.Parse(values[3]));
            

        }

    }

    public Vector3 getPosition()
    {
        return position;
    }

    public Vector3 getAngle()
    {
        return angle;
    }

    public void closeMovePort()
    {
        _streamMove.Close();
        threadMove.Abort();
    }

    public void closeRotatePort()
    {
        _streamRotate.Close();
        threadRotate.Abort();
    }

    public string[] getPortNames()
    {
        return portNames;
    }
}
