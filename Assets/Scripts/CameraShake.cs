using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeScale = 1f;
    public float shakeFrequency = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = Vector3.zero + (Vector3.up * Mathf.PerlinNoise(Time.time * shakeFrequency, 0)) * shakeScale;
    }
}
