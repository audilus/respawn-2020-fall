using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CamRaycast : MonoBehaviour
{
    public List<Ray> rays = new List<Ray>();
    public List<Collider> invalid = new List<Collider>();
    public RaycastHit raycast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Incredibly slow; Revisit this later to find a more efficient solution. Maybe spawn another thread or run it on the GPU.
        invalid.Clear();

        rays.Add(Camera.main.ViewportPointToRay(new Vector3(0,0,0)));
        rays.Add(Camera.main.ViewportPointToRay(new Vector3(1,1,0)));
        rays.Add(Camera.main.ViewportPointToRay(new Vector3(0,1,0)));
        rays.Add(Camera.main.ViewportPointToRay(new Vector3(1,0,0)));

        rays.Add(Camera.main.ViewportPointToRay(new Vector3(0.5f,0,0)));
        rays.Add(Camera.main.ViewportPointToRay(new Vector3(0,0.5f,0)));
        rays.Add(Camera.main.ViewportPointToRay(new Vector3(1,0.5f,0)));
        rays.Add(Camera.main.ViewportPointToRay(new Vector3(0.5f,1,0)));

        foreach(Ray x in rays){
            Ray r = x;
            r.direction *= 1.2f;
            if (Physics.Raycast(r, out raycast)){
                invalid.Add(raycast.collider);
            }

        }
        rays.Clear();

        
    }
}
