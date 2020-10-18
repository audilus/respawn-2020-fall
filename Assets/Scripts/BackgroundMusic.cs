using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    AudioSource source;
    public float volume = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        source.volume = volume;
    }
    
    public void ChangeVol(float v)
    {
        volume = v;
    }

}
