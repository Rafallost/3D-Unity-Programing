using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinking : MonoBehaviour
{
    public Light myLight;
    public float minWaitTime;
    public float maxWaitTime;
    public float minLightIntensity;
    public float maxLightIntensity;

    void Start()
    {
        StartCoroutine(Blinking());
    }

    IEnumerator Blinking()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            myLight.intensity = Random.Range(minLightIntensity, maxLightIntensity);
        }
    }
}
