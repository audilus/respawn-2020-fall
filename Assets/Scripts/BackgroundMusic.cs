using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BackgroundMusic : MonoBehaviour
{

    AudioSource source;
    public AudioMixer mixer;
    Slider slider;
    public float volume = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        source.volume = slider.value;
        
    }
    
    public void ChangeVol(float v)
    {
        mixer.SetFloat("MyExposedParam", Mathf.Log10(v) * 20);
    }

}
