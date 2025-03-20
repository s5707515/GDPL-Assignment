using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemy : MonoBehaviour
{
    [SerializeField] private int score = 1;

    [SerializeField] private GameObject smokeEffectPrefab;

    private GameUI gameUIScript;

    private bool quitting = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameUIScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GameUI>();
    }


    private void OnDestroy()
    {
        if(!quitting)
        {
            //Spawn smoke cloud effect
            Instantiate(smokeEffectPrefab, transform.position, transform.rotation);

            //Increment score
            gameUIScript.IncrementScore(score);
        }
       

        Debug.Log("Object Destroyed");
    }

    private void OnApplicationQuit()
    {
        quitting = true;
    }
}
