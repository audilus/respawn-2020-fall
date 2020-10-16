using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraHide : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Collider collider;
    private Collider playerCollider;
    
    void Awake()
    {
        collider = GetComponent<Collider>();
        // collider.contactOffset = 0.1f;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start(){
        playerCollider = FindObjectOfType<PlayerMovement>().GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        if(collider.isTrigger && collider.bounds.Intersects(playerCollider.bounds))
        {
            collider.isTrigger = true;
        }else{
            collider.isTrigger = !meshRenderer.isVisible;
        }
        Debug.Log(meshRenderer.isVisible);
    }
}
