using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitator : Activator
{
    public float newHeight = 5f;
    public float moveRate = 1f;
    public bool invert = false;
    private Vector3 basePos;
    // Start is called before the first frame update
    void Start()
    {
        basePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isActive());
        if (!invert)
        {
            if (isActive())
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(basePos.x, basePos.y + newHeight, basePos.z), moveRate * Time.deltaTime);

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, basePos, moveRate * Time.deltaTime);
            }
        }
        else
        {
            if (!isActive())
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(basePos.x, basePos.y + newHeight, basePos.z), moveRate * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, basePos, moveRate * Time.deltaTime);
            }
        }

    }
}
