using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSounds : MonoBehaviour {

    AudioSource sound;

    public void playSouns()
    {
        if(sound == null)
        {
            sound = searchAudio();
        }

        sound.Play();
    }

    public void StopSound()
    {

        sound.Stop();
    }

    private AudioSource searchAudio()
    {
        AudioSource[] audioS = GetComponentsInChildren<AudioSource>();
        AudioSource AudioS = null;

        foreach (AudioSource a in audioS)
        {
            if (a.name == "SoundClock")
            {
                AudioS = a;
            }
        }

        return AudioS;
    }
}
