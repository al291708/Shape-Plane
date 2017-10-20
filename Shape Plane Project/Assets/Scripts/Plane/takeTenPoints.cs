using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeTenPoints : MonoBehaviour {

    private int initFontSize;
    private int finalFontSize;

    private bool isVisible;

    private void Start()
    {
        initFontSize = 16;
        finalFontSize = 145;

        resetValues();
    }

    private void Update()
    {
        if (isVisible)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    public void takeWall()
    {
        GetComponent<MeshRenderer>().enabled = true;
        isVisible = true;
        StartCoroutine("increaseFontSize");

    }

    IEnumerator increaseFontSize()
    {
        while (GetComponent<TextMesh>().fontSize < finalFontSize)
        {
            yield return new WaitForSeconds(0.001f);
            GetComponent<TextMesh>().fontSize += 3; ;
        }

        yield return new WaitForSeconds(0.5f);
        resetValues();

    }

    private void resetValues()
    {
        GetComponent<TextMesh>().fontSize = initFontSize;
        GetComponent<MeshRenderer>().enabled = false;

        isVisible = false;
    }
}
