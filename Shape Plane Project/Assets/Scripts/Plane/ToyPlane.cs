using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPlane : MonoBehaviour {
	private int lifes;

    private bool isSlow;
	
    void Start()
    {
        lifes = 3;
        isSlow = false;
    }

    //Life code
    public void takeALife()
    {
        lifes--;
    }

    public void addALife()
    {
        lifes++;
    }

    public int getLifes()
    {
        return lifes;
    }

    public void setLifes(int newLife)
    {
        lifes = newLife;
    }

    //Slow code
    public bool getIsSlow()
    {
        return isSlow;
    }

    public void setIsSlow(bool b)
    {
        isSlow = b;
    }
}
