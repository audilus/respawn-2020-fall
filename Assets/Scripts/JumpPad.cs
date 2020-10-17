using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float JumpPower = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider c){

        c.attachedRigidbody.AddForce( (transform.up + transform.forward) * JumpPower, ForceMode.Impulse);
        Debug.Log(transform.up);
        Debug.Log($"{c.gameObject.name} entered {this}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
