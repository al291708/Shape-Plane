using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveSounds : MonoBehaviour {

    public void playSouns()
    {
        AudioSource[] audioS = GetComponentsInChildren<AudioSource>();

        foreach (AudioSource a in audioS)
        {
            Debug.Log(a.name);
            if (a.name == "SoundLlave")
            {
                a.Play();
            }
        }
    }
}
