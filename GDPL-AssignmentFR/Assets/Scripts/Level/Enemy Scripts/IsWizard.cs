using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWizard : IsEnemy
{

    bool hasTeleported = false;
    
    [SerializeField] private Transform tpSpot;

    [SerializeField] protected GameObject wizardSmoke;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    

    protected override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            if (!hasTeleported) //Teleport the enemy
            {
                Teleport(tpSpot);
            }
            else //Destroy the enemy
            {

                Destroy(gameObject);

            }
        }

        
    }
    protected override void OnDestroy()
    {
        if (!quitting)
        {
            //Spawn smoke cloud effect
            Instantiate(smokeEffectPrefab, transform.position, transform.rotation);

            //Increment score
            gameManagerScript.IncrementScore(score);

            //Destroy the holder object on defeat
            Destroy(gameObject.transform.parent.gameObject);
        }


        Debug.Log("Object Destroyed");
        
    }

    private void Teleport(Transform location) //Teleport the enemy to a new location
    {
        rb.isKinematic = true;

        Instantiate(wizardSmoke, transform.position, transform.rotation);

        transform.position = location.position;

        Instantiate(wizardSmoke, transform.position, transform.rotation);


        hasTeleported = true;

        rb.isKinematic = false;

    }

}
