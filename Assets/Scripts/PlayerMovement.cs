using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float acceleration = 10f;
    public float maxFloorVelocity = 90f;
    public float maxAirVelocity = 30f;
    public float floorVelocityDampening = 0.7f;
    public float jumpPower = 4f;
    public float gravityMult = 4f;
    public float airAccel = 0.1f;
    public float airTimeLimit = 2f;
    public int jumpFrameDelay = 5;

    private Rigidbody rigidbody;
    private bool isGrounded = true;
    private int jumpDelay = 0;
    private float airTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Fixed update is called every physics tick (locked at 60Hz), so I don't need to multiply by time.deltatime here
    void FixedUpdate()
    {
        
    }

    void Update()
    {
        Vector3 final = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z);
        jumpDelay--;



        if(isGrounded){
            final = new Vector3(rigidbody.velocity.x * floorVelocityDampening, rigidbody.velocity.y, rigidbody.velocity.z * floorVelocityDampening);
        }
        
        if ((final.magnitude <= maxFloorVelocity) && isGrounded)
        {
            final += Input.GetAxis("Vertical") * transform.forward * acceleration;
            final += Input.GetAxis("Horizontal") * transform.right * acceleration;
        }
        // else if ((final.magnitude <= maxAirVelocity) && airTime > 0)
        // {
        //     final += Input.GetAxis("Vertical") * transform.forward * (airAccel * airTime + 1);
        //     final += Input.GetAxis("Horizontal") * transform.right * (airAccel * airTime );    
        // }

        airTime -= Time.deltaTime;
        Debug.Log(airTime);

        final += Vector3.down * gravityMult * Time.deltaTime;
        rigidbody.velocity = final;

        if (Input.GetButton("Jump") && isGrounded && (jumpDelay <= 0))
        {
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jumpDelay = jumpFrameDelay;
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
            {
                if (hit.collider.enabled){
                    isGrounded = true;
                    airTime = airTimeLimit;
                }   
                else{
                    isGrounded = false;
                }
            }
            else
            {
                isGrounded = false;
            }
        }
    }
}
