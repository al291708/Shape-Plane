using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour {

    private float velocity;
    // Use this for initialization
    void Start () {
        velocity = GameObject.FindGameObjectWithTag("GameController").GetComponent<SlowManager>().getVelocity();

        Destroy(this.gameObject, 1f);
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, -velocity/2);

    }
}
