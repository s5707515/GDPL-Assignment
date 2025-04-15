using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class isDecoration : MonoBehaviour
{
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Check if the object has been affected by a force and apply gravity to it

        if(rb.velocity.magnitude > 0.1f)
        {
            rb.useGravity = true;

            Destroy(this); //Destroy this instance of the script as it no longer needs to be used
        }
    }
}
