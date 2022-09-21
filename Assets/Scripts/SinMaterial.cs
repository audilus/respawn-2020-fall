using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMaterial : MonoBehaviour
{
    Renderer renderer;
    public float frequency = 1f;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.SetFloat("_Middle", Mathf.Sin(Time.timeSinceLevelLoad * frequency));
    }
}
