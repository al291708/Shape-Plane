using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMaterials : MonoBehaviour {

    public Material opaque;
    public Material transparent;

    public void changeToTransparent()
    {
        GetComponent<MeshRenderer>().material = transparent;
    }

    public void changeToOpaque()
    {
        GetComponent<MeshRenderer>().material = opaque;
    }
}
