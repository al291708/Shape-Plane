using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMaterials : MonoBehaviour {

    public Material opaque;
    public Material goodTransparent;
    public Material badTransparent;

    private bool isTransparent = false;

    public void changeToGoodTransparent()
    {
        GetComponent<MeshRenderer>().material = goodTransparent;
        isTransparent = true;
    }

    public void changeToBadTransparent()
    {
        GetComponent<MeshRenderer>().material = badTransparent;
        isTransparent = true;

    }

    public void changeToOpaque()
    {
        GetComponent<MeshRenderer>().material = opaque;
        isTransparent = false;

    }

    public bool getIsTransparent()
    {
        return isTransparent;
    }

    public void setIsTransparent(bool b)
    {
        isTransparent = b;
    }
}
