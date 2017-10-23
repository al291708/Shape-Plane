using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPoints : MonoBehaviour {
    private int initFontSize;
    private int finalFontSize;

    private bool isVisible;

    private string plusTenText;
    private string minusTenText;

    private void Start()
    {
        initFontSize = 16;
        finalFontSize = 145;

        plusTenText = "+ 10";
        minusTenText = "- 10";


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
        GetComponent<TextMesh>().text = plusTenText;
        isVisible = true;
        StartCoroutine("increaseFontSize");

    }

    public void hitWall()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<TextMesh>().text = minusTenText;
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
        GetComponent<TextMesh>().text = "";

        isVisible = false;
    }
}
