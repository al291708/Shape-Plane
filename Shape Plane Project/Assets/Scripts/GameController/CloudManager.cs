using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour {
	
	private List<GameObject> clouds = new List<GameObject>();
	public  List<GameObject> cloudKind;
	public float speed;


	private GameObject plane;
	private GameObject camera;
    private GameObject gameController;

	// Use this for initialization
	void Start () {
		plane = GameObject.FindGameObjectWithTag ("Player");
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
        gameController = GameObject.FindGameObjectWithTag("GameController");

		for (int i = 0; i < 2; i++)
		{
			instantiateRandomCloud ();
		}

		clouds [0].SetActive (true);

		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (plane.GetComponent<ToyPlane>().isAlive () && !gameController.GetComponent<PauseMenuScript>().isGamePaused ()) {
			if (clouds [0].transform.position.z > camera.transform.position.z) {
				clouds [0].transform.position += new Vector3 (0, 0,speed);
			} else {
				Destroy (clouds [0]);
				clouds.RemoveAt (0);
				clouds [0].SetActive (true);

				instantiateRandomCloud ();
			}
		}
	}	

	void instantiateRandomCloud ()
	{
		int randomCloudTypeIndex = Random.Range (0, cloudKind.Count);
		GameObject randCloud = Instantiate (cloudKind [randomCloudTypeIndex], new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity)as GameObject;
		randCloud.SetActive (false);
		clouds.Add (randCloud);
	}
				
		
	}

