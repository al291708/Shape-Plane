﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {

    private List<GameObject> walls = new List<GameObject>();
    public List<GameObject> wallTypes;

    private GameObject plane;
    private GameObject camera;

    private float ratioOfSpawnWall;

    // Use this for initialization
    void Start () {
        plane = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        ratioOfSpawnWall = 7f;

        for (int i = 0; i < 2; i++)
        {
            instantiateRandomWall();
        }

        walls[0].SetActive(true);

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(plane.GetComponent<ToyPlane>().isAlive() && !GetComponent<PauseMenuScript>().isGamePaused())
        {
            if (walls[0].transform.position.z > camera.transform.position.z)
            {
                if (plane.GetComponent<ToyPlane>().getIsSlow())
                {
                    walls[0].transform.position += new Vector3(0, 0, -0.4f);
                }
                else
                {
                    walls[0].transform.position += new Vector3(0, 0, -0.8f);

                }
            }else {
                Destroy(walls[0]);
                walls.RemoveAt(0);
                walls[0].SetActive(true);

                GetComponent<SlowManager>().setNextPowerUps(GetComponent<SlowManager>().getNextPowerUps() - 1);

                instantiateRandomWall();
            }
        }
	}

    void instantiateRandomWall()
    {
        int randomWallTypeIndex = Random.Range(0, wallTypes.Count);
        GameObject randomWall = Instantiate(wallTypes[randomWallTypeIndex], calculeRandomPointInCircle(ratioOfSpawnWall), Quaternion.Euler(new Vector3(0f,0f,Random.Range(-50f,50f)))) as GameObject;
        
        randomWall.SetActive(false);
        walls.Add(randomWall);
    }

    private Vector3 calculeRandomPointInCircle(float ratio)
    {
        float angleDegreesRdn = Random.Range(0f, 369f);
        float angle = Mathf.PI * angleDegreesRdn / 180f;
        float disCenterRdn = Random.Range(0, ratio);
        
        return new Vector3(Mathf.Sin(angle) * disCenterRdn, Mathf.Cos(angle) * disCenterRdn, 150f);
    }
    
}
