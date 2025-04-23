using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemy : MonoBehaviour
{
    [SerializeField] protected int score = 1;

    [SerializeField] protected GameObject smokeEffectPrefab;

    [SerializeField] private float getUpSpeed = 5.0f;

    protected GameManager gameManagerScript;


    protected bool quitting = false;

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

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
