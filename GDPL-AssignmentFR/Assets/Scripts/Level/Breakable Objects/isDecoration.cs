using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class isDecoration : MonoBehaviour
{
    private Rigidbody rb;

    bool hasToggled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Check if the object has been affected by a force and apply gravity to it

        if(rb.velocity.magnitude > 0.1f && !hasToggled)
        {
            rb.useGravity = true;

            hasToggled = true;
        }
    }
}
