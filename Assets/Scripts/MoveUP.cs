using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") != 0){
            transform.Translate(new Vector3(0, Input.GetAxisRaw("Vertical") * Time.deltaTime * 60f,0));
        }else{
            transform.Translate((Vector3.zero - transform.position) * Time.deltaTime);
        }
    }
}
