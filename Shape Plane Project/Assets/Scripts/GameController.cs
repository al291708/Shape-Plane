using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private List<GameObject> walls = new List<GameObject>();
    private List<GameObject> powerUps = new List<GameObject>();
    public List<GameObject> wallTypes;
    public List<GameObject> powerUpTypes;
    public Transform camara;
    private bool isAlive = true;
    bool isSlow = true;

    private int nextPowerUp;
    
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 3; i++)
        {
            instantiateRandomWall();
            instantiateRandomPowerUp();
        }
        walls[0].SetActive(true);
        nextPowerUp = Random.Range(2, 5);
    }
	
	// Update is called once per frame
	void Update () {
        if (isAlive)
        {
            if (powerUps[0].activeSelf)
            {
                if (powerUps[0].transform.position.z > camara.position.z)
                {
                    powerUps[0].transform.position += new Vector3(0, 0, -0.2f);
                } else
                {
                    Destroy(powerUps[0]);
                    powerUps.RemoveAt(0);
                    instantiateRandomPowerUp();
                }
            }

            if (walls[0].transform.position.z > camara.position.z )
            {
                if (isSlow==true)
                {
					
                    walls[0].transform.position += new Vector3(0, 0, -1);
                }
				else if(isSlow==false)
                {
                    walls[0].transform.position += new Vector3(0, 0, -0.1f);
                }

                if (powerUps[0].activeSelf)
                {
                    powerUps[0].transform.position += new Vector3(0, 0, -0.2f);
                }
            } else {
                Destroy(walls[0]);
                walls.RemoveAt(0);
                walls[0].SetActive(true);

                nextPowerUp -= 1;
                if (nextPowerUp == 0)
                {
                    powerUps[0].SetActive(true);
                    nextPowerUp = Random.Range(2, 5);
                }
                instantiateRandomWall();
            }
        }
	}

    void instantiateRandomWall()
    {
        int randomWallTypeIndex = Random.Range(0, wallTypes.Count);
        GameObject randomWall = Instantiate(wallTypes[randomWallTypeIndex], new Vector3(0, 0, 150), Quaternion.identity) as GameObject;
        //Debug.Log(randomWall);
        randomWall.SetActive(false);
        walls.Add(randomWall);
    }

    void instantiateRandomPowerUp()
    {
        int randomPowerUpTypeIndex = Random.Range(0, powerUpTypes.Count);
        GameObject randomPowerUp = Instantiate(powerUpTypes[randomPowerUpTypeIndex], new Vector3(0, 0, 75), Quaternion.identity) as GameObject;
        //Debug.Log(randomPowerUp);
        randomPowerUp.SetActive(false);
        powerUps.Add(randomPowerUp);
    }
    public void setIsSlow(bool slow)
    {
        isSlow = slow;
    }
	public bool getIsSlow(){
		return isSlow;
	}


    
}
