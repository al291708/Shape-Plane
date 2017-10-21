using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsMaterial : MonoBehaviour {

    public Material transp;

    public void makeTransparent()
    {
        GetComponentInChildren<MeshRenderer>().material = transp;
    }
}
