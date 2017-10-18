using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowManager : MonoBehaviour {

    private List<GameObject> powerUpInstanciates = new List<GameObject>();
    public List<GameObject> powerUpTypes;

    private GameObject plane;
    private GameObject camera;

    public float slowTime;

    public int nextPowerUp;

    void Start () {
        plane = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        for (int i = 0; i < 2; i++)
        {
            instantiateRandomPowerUp();
        }

        slowTime = 5f;
        nextPowerUp = Random.Range(2, 5);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (plane.GetComponent<ToyPlane>().isAlive() && !GetComponent<PauseMenuScript>().isGamePaused())
        {
            if (nextPowerUp == 0)
            {
                powerUpInstanciates[0].SetActive(true);

                instantiateRandomPowerUp();
                nextPowerUp = Random.Range(2, 5);
            }

            if (powerUpInstanciates[0].activeSelf)
            {
                powerUpInstanciates[0].transform.position += new Vector3(0, 0, -0.8f);
            }

            if (powerUpInstanciates[0].transform.position.z < camera.transform.position.z)
            {
                Destroy(powerUpInstanciates[0]);
                powerUpInstanciates.RemoveAt(0);
            }


            if (plane.GetComponent<ToyPlane>().getIsSlow())
            {
                slowTime -= Time.deltaTime;
                if (slowTime < 0)
                {
                    plane.GetComponent<ToyPlane>().setIsSlow(false);
                    slowTime = 5f;
                }

            }
        }
    }

    void instantiateRandomPowerUp()
    {
        int randomPowerUpTypeIndex = Random.Range(0, powerUpTypes.Count);
        GameObject PU = Instantiate(powerUpTypes[randomPowerUpTypeIndex], new Vector3(0, 0, 75), Quaternion.identity) as GameObject;
        PU.SetActive(false);
        powerUpInstanciates.Add(PU);
    }

    public int getNextPowerUps()
    {
        return nextPowerUp;
    }

    public void setNextPowerUps(int n)
    {
        nextPowerUp = n;
    }
}
