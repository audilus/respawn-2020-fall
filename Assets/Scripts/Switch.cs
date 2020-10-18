using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Activator activator;
    private CamRaycast camRaycast;
    private MeshRenderer meshRenderer;
    new private Collider collider;
    private float clock = 0;
    // Start is called before the first frame update
    void Start()
    {
        camRaycast = FindObjectOfType<CamRaycast>();
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(clock < 0.999f){
            clock += Time.deltaTime * 0.5f;
        }else{
            clock = 0f;
            clock += Time.deltaTime * 0.5f;
        }
        meshRenderer.material.SetFloat("_Middle", clock);

        if (meshRenderer.isVisible && !camRaycast.invalid.Contains(collider)){
            Debug.Log("  ");
            activator.SetActive(true);
        }else{
            activator.SetActive(false);
        }
    }
}
