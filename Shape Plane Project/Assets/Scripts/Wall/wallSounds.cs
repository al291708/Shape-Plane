using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallSounds : MonoBehaviour {

    public AudioClip passWallSound;
    public AudioClip hitWallSounds;

    private AudioSource soundManager;

    private float volumePassWall;
    private float volumeHitWall;

    void Start()
    {
        soundManager = GetComponent<AudioSource>();

        volumePassWall = 0.4f;
        volumeHitWall = 0.3f;
    }

    public void playPassWallSound()
    {
        soundManager.PlayOneShot(passWallSound, volumePassWall);
    }

    public void playHitWallSound()
    {
        soundManager.PlayOneShot(hitWallSounds, volumeHitWall);
    }
}
