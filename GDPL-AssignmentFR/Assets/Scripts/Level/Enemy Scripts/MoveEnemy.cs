using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != checkPoints[pointer].position)
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
