using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject brokenVersion;

    [SerializeField] private float breakForce = 2;

    [SerializeField] private float collisionMultiplier;

    [SerializeField] private bool isBroken;

    private void OnCollisionEnter(Collision collision)
    {
        if(isBroken)
        {
            return;
        }

        //Break the object if it is hit by an object with a significant force

        if(collision.relativeVelocity.magnitude >= breakForce)
        {
            isBroken = true;

            //Instantiate broken object and get rbs of all fractured segments
            
            var brokenObject = Instantiate(brokenVersion, transform.position, transform.rotation);

            var rbs = brokenObject.GetComponentsInChildren<Rigidbody>();

            foreach(var rb in rbs)
            {
                rb.AddExplosionForce(collision.relativeVelocity.magnitude * collisionMultiplier, collision.contacts[0].point, 2);
            }


            //Destroy the unbroken object

            Destroy(gameObject);

        }
    }
}
