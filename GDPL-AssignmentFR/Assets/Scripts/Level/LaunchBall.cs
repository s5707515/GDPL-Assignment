using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{


    [Header("References")]

    [SerializeField] private GameObject ball;

    [SerializeField] private Transform spawnPos;
    [SerializeField] private Rigidbody ballRb;

    [SerializeField] private AimCannon cannonScript;




    private void Start()
    {
        ball.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if(other.CompareTag("Enemy"))
        {
            HideBall();
        }
    }

    //Fire ball from cannon with correct forces applied
    public void FireBall(float yTilt, float zTilt, float power)
    {
        ball.SetActive(true);

        ballRb.isKinematic = true;

        //Reset properties

        ballRb.velocity = Vector3.zero;
        ball.transform.position = spawnPos.position;
        

        ballRb.isKinematic = false;

        ball.transform.rotation = Quaternion.Euler(0, -zTilt, yTilt);

        ballRb.velocity = new Vector3(0, -zTilt, yTilt) * power;
    }

    //Pooling with one item (effectively despawning the ball)

    public void HideBall()
    {
        cannonScript.ResetCannon();

        ball.SetActive(false);
    }

    
}

