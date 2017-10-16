using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {

    private List<GameObject> walls = new List<GameObject>();
    public List<GameObject> wallTypes;

    private GameObject plane;
    private GameObject camera;

    // Use this for initialization
    void Start () {
        plane = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");

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
                if (walls[0].transform.position.z < plane.GetComponent<Transform>().position.z)
                {
                    walls[0].GetComponentInChildren<wallMaterials>().changeToTransparent();
                }

                if (plane.GetComponent<ToyPlane>().getIsSlow())
                {
                    walls[0].transform.position += new Vector3(0, 0, -0.25f);
                }
                else
                {
                    walls[0].transform.position += new Vector3(0, 0, -0.5f);

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
        GameObject randomWall = Instantiate(wallTypes[randomWallTypeIndex], new Vector3(0, 0, 150), Quaternion.identity) as GameObject;
        randomWall.SetActive(false);
        walls.Add(randomWall);
    }
    
}
