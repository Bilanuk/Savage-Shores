using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    // make a script that makes the light flicker scary like in the movies

    [SerializeField] private Light light;
    public float minIntensity = 0.25f;
    public float maxIntensity = 1.0f;
    public float flickerSpeed = 0.1f;

    private Light lightSource;

    void Start()
    {
        lightSource = GetComponent<Light>();
    }

    void Update()
    {
        float flicker = Mathf.PingPong(Time.time * flickerSpeed, 1.0f);
        lightSource.intensity = Mathf.Lerp(minIntensity, maxIntensity, flicker);
    }
}
