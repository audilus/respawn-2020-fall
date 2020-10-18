using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField]
    protected bool active = false;

    public void Activate(){
        active = false;
    }

    public void Deactivate(){
        active = false;
    }

    public void SetActive(bool x){
        active = x;
    }
    public bool isActive(){
        return active;
    }
}
