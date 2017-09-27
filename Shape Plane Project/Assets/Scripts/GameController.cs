using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private List<GameObject> walls = new List<GameObject>();
    public List<GameObject> wallTypes;
    public Transform camara;
    private bool isAlive = true;
    
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 3; i++)
        {
            instantiateRandomWall();
        }
        walls[0].SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (isAlive)
        {
            if (walls[0].transform.position.z > camara.position.z )
            {
                walls[0].transform.position += new Vector3(0, 0, -1);
            } else {
                Destroy(walls[0]);
                walls.RemoveAt(0);
                walls[0].SetActive(true);
                instantiateRandomWall();
            }
        }
	}

    void instantiateRandomWall()
    {
        int randomWallTypeIndex = Random.Range(0, wallTypes.Count);
        GameObject randomWall = Instantiate(wallTypes[randomWallTypeIndex], new Vector3(0, 0, 150), Quaternion.identity) as GameObject;
        Debug.Log(randomWall);
        randomWall.SetActive(false);
        walls.Add(randomWall);
    }
}
