using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class isDecoration : MonoBehaviour
{
    private Rigidbody rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = false;

        Destroy(this); //Destroy the script as it is no longer necessary
    }
    
   
}
