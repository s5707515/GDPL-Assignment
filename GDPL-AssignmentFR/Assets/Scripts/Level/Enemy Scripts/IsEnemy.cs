using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemy : MonoBehaviour
{
    [SerializeField] protected int score = 1;

    [SerializeField] protected GameObject smokeEffectPrefab;

    protected GameManager gameManagerScript;

    protected LaunchBall launchBallScript;



    protected bool quitting = false;



    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            launchBallScript.HideBall();

            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        launchBallScript = GameObject.FindGameObjectWithTag("Pool").GetComponent<LaunchBall>();
     
    }

    




    protected virtual void OnDestroy()
    {
        if(!quitting)
        {
            //Spawn smoke cloud effect
            Instantiate(smokeEffectPrefab, transform.position, transform.rotation);

            //Increment score
            gameManagerScript.IncrementScore(score);
        }
       

        Debug.Log("Object Destroyed");
    }

    protected void OnApplicationQuit()
    {
        quitting = true;
    }
}
