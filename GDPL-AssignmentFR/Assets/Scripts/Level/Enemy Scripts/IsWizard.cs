using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWizard : IsEnemy
{

    bool hasTeleported = false;
    
    [SerializeField] private Transform tpSpot;

    [SerializeField] protected GameObject wizardSmoke;

    [SerializeField] private AudioClip tpSFX;


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

                //Spawn smoke cloud effect
                Instantiate(smokeEffectPrefab, transform.position, transform.rotation);

                //Play SFX

                audioManagerScript.PlaySFX(dingSFX);

                //Increment score
                gameManagerScript.IncrementScore(score);

                //Destroy the holder object on defeat
                Destroy(gameObject.transform.parent.gameObject);

            }

            launchBallScript.HideBall();
        }
    }


    
   

    private void Teleport(Transform location) //Teleport the enemy to a new location
    {
        rb.isKinematic = true;

        Instantiate(wizardSmoke, transform.position, transform.rotation);

        transform.position = location.position;

        Instantiate(wizardSmoke, transform.position, transform.rotation);

        audioManagerScript.PlaySFX(tpSFX);

        hasTeleported = true;

        rb.isKinematic = false;

    }

}
