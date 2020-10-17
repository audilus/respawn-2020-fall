using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleTarget : MonoBehaviour
{
    Renderer m_renderer;

    [SerializeField]
    public static List<GrappleTarget> activeGrappleTargets = new List<GrappleTarget>();
    [SerializeField]
    public static List<GrappleTarget> grappleTargets = new List<GrappleTarget>();
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        grappleTargets.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
        isActive = m_renderer.isVisible;
        Debug.Log(isActive);
        if(isActive){
            activeGrappleTargets.Add(this);
        }
        else {
            activeGrappleTargets.Remove(this);
        }
    }

    public bool GetIsActive(){
        return isActive;
    }
}
