using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IsEnemy : MonoBehaviour
{
    [SerializeField] protected int score = 1;

    [SerializeField] protected GameObject smokeEffectPrefab;

    protected GameManager gameManagerScript;

    protected LaunchBall launchBallScript;

    protected Rigidbody rb;

    bool getUpQueued = false;

    [Header("Getting Up Attributes")]

    [SerializeField] private int delay = 3;

    [SerializeField] private float standUpTime = 1.5f;


    protected void Update()
    {
        if(Vector3.Dot(transform.up, Vector3.up) < 0.5f && !getUpQueued) //If the enemy is not mostly upright
        {
            Debug.Log("Enemy has fallen");

            StartCoroutine(GetUp(delay));

            
        }
    }
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

        rb = gameObject.GetComponent<Rigidbody>();

        getUpQueued = false;

    }

    public IEnumerator GetUp(int delay) //Make the enemy stand up straight after a certain amount of time
    {
        getUpQueued = true;

        yield return new WaitForSeconds(delay);

        rb.isKinematic = true;

        Quaternion fallenRotation = transform.rotation;

        Quaternion uprightRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        float time = 0;

        while(time < standUpTime) //Smooth transition bewteen fallen over and upright
        {
            transform.rotation = Quaternion.Slerp(fallenRotation, uprightRotation, time / standUpTime);

            time += Time.deltaTime;
            yield return null;
        }

        //Make sure the enemy stands up

        transform.rotation = uprightRotation;
        Debug.Log("Enemy Stood Back Up!");

        rb.isKinematic = false;

        getUpQueued = false;

    }

    
}
