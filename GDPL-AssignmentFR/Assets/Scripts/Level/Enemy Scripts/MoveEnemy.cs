using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] checkPoints;

    [SerializeField] private float enemySpeed;


    private float numCheckPoints;

    private int pointer = 0;



    // Start is called before the first frame update
    void Start()
    {
        numCheckPoints = checkPoints.Length;

        if(numCheckPoints != 0)
        {
            transform.LookAt(checkPoints[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, checkPoints[pointer].position) > 1.0f) //If we're not close enough to next checkpoint
        {
            //Move towards that checkpoint

            MoveTowardsCheckPoint(checkPoints[pointer]);
        }
        else
        {
            //Cycle to next checkpoint position

            if (pointer == numCheckPoints - 1) 
            {
                pointer = 0;
            }
            else
            {
                pointer++;
            }

            //Turn towards the next checkpoint

            transform.LookAt(checkPoints[pointer]);
        }
    }

    void MoveTowardsCheckPoint(Transform point)
    {
        
        transform.position = Vector3.MoveTowards(transform.position, point.position, enemySpeed * Time.deltaTime);

    }

    private void OnDestroy()
    {
        //Destroy the parent holder when this gameObject is destroyed

        Destroy(gameObject.transform.parent.gameObject);
    }
}
