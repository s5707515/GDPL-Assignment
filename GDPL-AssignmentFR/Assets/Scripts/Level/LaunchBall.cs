using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{


    [Header("References")]


    [SerializeField] private GameObject ball;
    
    [SerializeField] private Rigidbody ballRb;

    [SerializeField] private AimCannon cannonScript;

    [SerializeField] private Transform spawnPos;

    private void Start()
    {
        ball.SetActive(false);
    }

    public void FireBall(Quaternion direction, float power)
    {
        //Reset forces

        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;

        ballRb.isKinematic = true;

        //Set balls position to infront of cannon

        ball.transform.position = spawnPos.position;

        //Rotate the ball to the correct trajectory

        ball.transform.rotation = direction;

        ballRb.isKinematic = false;

        //Debug.Log(ball.transform.rotation.eulerAngles.x);
        //Debug.Log(ball.transform.rotation.eulerAngles.y);
        //Debug.Log(ball.transform.rotation.eulerAngles.z);

        ball.SetActive(true);

        //fire the ball "forward" 

        ballRb.velocity = -ball.transform.right * power;
    }
  
    //Pooling with one item (effectively despawning the ball until it is needed again)

    public void HideBall()
    {
        cannonScript.ResetCannon(); //This resets the cannons rotation, removes the timer etc

        ball.SetActive(false);
    }

    


}

