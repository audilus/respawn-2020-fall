using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Activator activator;
    private CamRaycast camRaycast;
    private MeshRenderer meshRenderer;
    public bool requireFullVision = false;
    new private Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        camRaycast = FindObjectOfType<CamRaycast>();
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponentInParent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (meshRenderer.isVisible && !camRaycast.invalid.Contains(collider)){
            if (requireFullVision)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, (this.transform.position - Camera.main.transform.position).normalized, out hit))
                {
                    if (hit.transform.gameObject == collider.gameObject || hit.transform.tag == "Player" || hit.transform.tag == "Switch")
                    {
                        activator.SetActive(true);
                    }
                    else
                    {
                        activator.SetActive(false);
                    }
                }
                else
                {
                    activator.SetActive(false);
                }
            }
            else
            {
                activator.SetActive(true);
            }
            
        }else{
            activator.SetActive(false);
        }
    }
}
