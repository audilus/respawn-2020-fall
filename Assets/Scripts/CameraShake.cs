using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeScale = 1f;
    public float shakeFrequency = 20f;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = rigidbody.transform.eulerAngles;
        Shake(shakeScale);
        Debug.Log(rigidbody.velocity.magnitude);
        if (rigidbody.velocity.magnitude >= 60f)
        {
            Shake(Mathf.Pow(rigidbody.velocity.magnitude * 0.01f,2));
        }
    }

    public void Shake(float s)
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(Mathf.PerlinNoise(0, Time.time * shakeFrequency) - 0.486f, 0, Mathf.PerlinNoise(Time.time * shakeFrequency, 0) - 0.5f) * s;
    }
}
