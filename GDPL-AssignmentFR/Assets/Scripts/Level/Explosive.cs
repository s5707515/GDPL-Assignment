using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField] private float explosionPower;

    [SerializeField] private float explosionRadius;

    [SerializeField] private ParticleSystem smokePrefab;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            CreateExplosion();
        }
    }



    private void CreateExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider collider in colliders)
        {
            Rigidbody otherRb = collider.GetComponent<Rigidbody>();

            if (otherRb != null)
            {
          
                if (!otherRb.gameObject.CompareTag("Ball")) // Make ball immune to explosion
                {
                    otherRb.AddExplosionForce(explosionPower, transform.position, explosionRadius, 0.1f, ForceMode.Impulse);
                }
                
            }
           
            
        }
        Instantiate(smokePrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    public Transform GetCentre()
    {
        return transform;
    }

    public float GetRadius()
    {
        return explosionRadius;
    }
}
