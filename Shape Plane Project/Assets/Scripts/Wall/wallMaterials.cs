using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMaterials : MonoBehaviour {

    public Material opaque;
    public Material goodTransparent;
    public Material badTransparent;

    public void changeToGoodTransparent()
    {
        GetComponent<MeshRenderer>().material = goodTransparent;
    }

    public void changeToBadTransparent()
    {
        GetComponent<MeshRenderer>().material = badTransparent;
    }

    public void changeToOpaque()
    {
        GetComponent<MeshRenderer>().material = opaque;
    }
}
