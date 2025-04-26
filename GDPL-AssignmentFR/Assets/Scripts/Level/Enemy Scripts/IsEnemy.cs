using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemy : MonoBehaviour
{
    [SerializeField] protected int score = 1;

    [SerializeField] protected GameObject smokeEffectPrefab;

    protected GameManager gameManagerScript;

    protected LaunchBall launchBallScript;





    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            launchBallScript.HideBall();

            //Spawn smoke cloud effect
            Instantiate(smokeEffectPrefab, transform.position, transform.rotation);

            //Increment score
            gameManagerScript.IncrementScore(score);

            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        launchBallScript = GameObject.FindGameObjectWithTag("Pool").GetComponent<LaunchBall>();

    }
}
