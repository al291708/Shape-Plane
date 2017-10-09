using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPlane : MonoBehaviour {
	public int lifes= 3;
    public int currentLifes;
	// Use this for initialization
	void Start () {
        currentLifes = lifes;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void takeLife(int amount)
    {
        currentLifes -= amount;

    }
    public void addLife(int amount)
    {
        currentLifes += amount;
    }
    public int getLifes()
    {
        return lifes;
    }
    public void setLifes(int newLife)
    {
        lifes = newLife;
    }
}
