using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {

    private bool isDie = false;

    public void die()
    {
        if (!isDie)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;

            GetComponent<Rigidbody>().AddForce(Vector3.down * 2, ForceMode.Impulse);

            StartCoroutine("rotateZ", 0f);

            isDie = true;
        }
    }

    IEnumerator rotateZ(float r)
    {
        yield return new WaitForSeconds(0.01f);
        
        float rotacion = r;
        
        transform.eulerAngles = new Vector3(rotacion, -90f, rotacion);
        rotacion--;

        if(rotacion > 90)
        {
            StartCoroutine("rotateZ", r + 1);
        }
    }
}
