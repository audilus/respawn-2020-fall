using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraHide : MonoBehaviour
{
    [Header("UNEVEN SCALING WILL BREAK THIS SCRIPT.")]
    private MeshRenderer meshRenderer;
    new private Collider collider;
    private Collider playerCollider;
    private CamRaycast camRaycast;
    
    void Awake()
    {
        //Iniitalize these variables when the program starts.
        collider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
        camRaycast = FindObjectOfType<CamRaycast>();
    }

    void Start(){
        //Iniitalize these variables when the object is loaded into the level.
        playerCollider = FindObjectOfType<PlayerMovement>().GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        //If the player is already inside the collider, keep the collider permeable. 
        //I'm using "isTrigger" because it allows objects to pass through, but keeps the collider active so that I can check if its being intersected.
        if(collider.isTrigger && collider.bounds.Intersects(playerCollider.bounds))
        {
            collider.isTrigger = true;
        }
        else
        {
            //If the renderer isn't visible within the camera view, make the collider a trigger.
            collider.isTrigger = !meshRenderer.isVisible || !camRaycast.invalid.Contains(collider);
        }
    }
}
