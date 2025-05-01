using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField] private float explosionPower;

    [SerializeField] private float explosionRadius;

    [SerializeField] private ParticleSystem smokePrefab;

    private ManageAudio audioManagerScript;

    [SerializeField] private AudioClip explosionSFX;

     private LaunchBall launchBallScript;

    private void Start()
    {
        launchBallScript = GameObject.FindGameObjectWithTag("Pool").GetComponent<LaunchBall>();
        audioManagerScript = GameObject.FindGameObjectWithTag("Audio").GetComponent<ManageAudio>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            CreateExplosion();
            launchBallScript.HideBall();
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
                if(otherRb.gameObject.CompareTag("Enemy")) //Kill all enemies in range
                {
                    otherRb.gameObject.GetComponent<IsEnemy>().IsDefeated();
                }
                else if (!otherRb.gameObject.CompareTag("Ball")) // Make ball immune to explosion
                {
                    otherRb.AddExplosionForce(explosionPower, transform.position, explosionRadius, 0, ForceMode.Impulse);
                }
                
            }
           
            
        }

        Instantiate(smokePrefab, transform.position, Quaternion.identity);

        audioManagerScript.PlaySFX(explosionSFX);

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
