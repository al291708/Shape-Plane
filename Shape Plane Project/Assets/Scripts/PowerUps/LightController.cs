using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    Light light;

    float minRange = 6.5f;
    float maxRango = 13f;

    float time;

    bool isIncrease;

	// Use this for initialization
	void Start () {
        light = GetComponentInChildren<Light>();
        light.range = minRange;

        isIncrease = true;

        time = 0;
    }

    private void FixedUpdate()
    {
        time += 0.1f;

        light.range = valueBetweentwoValues(minRange, maxRango, Mathf.Sin(time));
    }

    private float valueBetweentwoValues(float min, float max, float value) //value -> [-1,1]
    {
        float newValue = value + 1f;

        float percentage = newValue / 2;

        float range = max - min;

        float percentageOfRange = range * percentage;

        float result = min + percentageOfRange;

        return result;
    }
}
