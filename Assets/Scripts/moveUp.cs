using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography;
using UnityEngine;

public class moveUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetAxisRaw("Vertical") <   0){
            transform.Translate(new Vector3(0, 0, -2.25f * Time.deltaTime));
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(new Vector3(0, 0, 2.25f * Time.deltaTime));
        }
         if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(new Vector3(-2.25f * Time.deltaTime, 0, 0));
        }
         if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(new Vector3(2.25f * Time.deltaTime, 0, 0));
        }
        if (Input.GetAxisRaw("Jump") > 0)
        {
            if (transform.position.y <= 0)
            {
                transform.Translate(new Vector3(0, 6f * Time.deltaTime, 0));
            }
            /*else
            {
                if (transform.position.y > 0)
                {
                    transform.Translate(new Vector3(0, -1.25f * Time.deltaTime, 0));
                }
            }*/
        }
        else
        {
            if (transform.position.y > 0)
            {
                transform.Translate(new Vector3(0, -1.25f * Time.deltaTime, 0));
            }
        }
    }

}
