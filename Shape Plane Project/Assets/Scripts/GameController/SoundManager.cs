using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private GameObject plane;
    public AudioSource audioSource;

    private bool isChangePitch = false;

    // Use this for initialization
    void Start () {
        plane = GameObject.FindGameObjectWithTag("Player");

       
    }

    // Update is called once per frame
    void Update () {

        //Debug.Log(plane.GetComponent<ToyPlane>().getIsSlow() + " && " + isChangePitch);
        if (plane.GetComponent<ToyPlane>().getIsSlow() && isChangePitch == false)
        {
            StartCoroutine("downPitch");
            isChangePitch = true;
            Debug.Log("bajo");

        }
        if (!plane.GetComponent<ToyPlane>().getIsSlow() && isChangePitch == false)
        {
            StartCoroutine("upPitch");
            isChangePitch = true;
        }

    }

    IEnumerator downPitch()
    {
        yield return new WaitForSeconds(0.1f);

        while (audioSource.pitch > 0.85f)
        {
            audioSource.pitch -= 0.02f;
            yield return new WaitForSeconds(0.1f);
        }
        isChangePitch = false;
    }

    IEnumerator upPitch()
    {
        yield return new WaitForSeconds(0.1f);

        while (audioSource.pitch < 1f)
        {
            audioSource.pitch += 0.04f;
            yield return new WaitForSeconds(0.08f);
        }
        isChangePitch = false;
    }
}
