using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    public float maxGrappleDist = 90f;
    public bool hasGHook = false;

    private GrappleTarget gTarget;
    private ConfigurableJoint joint;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // joint = player.GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasGHook && Input.GetButtonDown("Fire1") && joint == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, this.transform.forward, out hit, maxGrappleDist))
            {
                if (hit.transform.tag == "Grapple Target")
                {
                    gTarget = hit.transform.gameObject.GetComponent<GrappleTarget>();
                    if (!gTarget.GetIsActive())
                    {
                        gTarget = null;
                    }
                    else
                    {
                        joint = player.gameObject.AddComponent<ConfigurableJoint>();
                        joint.connectedBody = gTarget.GetComponent<Rigidbody>();
                        joint.autoConfigureConnectedAnchor = false;
                        joint.connectedAnchor = gTarget.transform.position;
                        joint.xMotion = ConfigurableJointMotion.Limited;
                        joint.yMotion = ConfigurableJointMotion.Limited;
                        joint.zMotion = ConfigurableJointMotion.Limited;
                        SoftJointLimit s = new SoftJointLimit();
                        s.limit = 20f;
                        joint.linearLimit = s;
                        //joint.connectedAnchor = gTarget.gameObject.transform.position;
                    }
                }
            }

        }
        
        if(joint != null && gTarget != null){
            joint.anchor = gTarget.gameObject.transform.position;
            joint.connectedAnchor = gTarget.gameObject.transform.position;
        }


        // if (gTarget != null)
        // {
        //     if (!gTarget.GetIsActive())
        //     {
        //         gTarget = null;
        //         joint.breakForce = 0;
        //     }
        // }
        // if (hasGHook && Input.GetButtonDown("Fire2"))
        // {
        //     joint.breakForce = 0;
        // }


    }

}
