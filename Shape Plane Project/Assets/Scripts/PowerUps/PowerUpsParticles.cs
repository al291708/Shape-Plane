using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsParticles : MonoBehaviour {

    public ParticleSystem particle;
    private ParticleSystem particleInstaciate = null;
    
    public void showParticles()
    {
        particleInstaciate = Instantiate(particle, transform.position, Quaternion.identity);

        particleInstaciate.Play();
    }
}
