using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] private float percentageChance;

    //SerializeField] private Transform spawnPos;

    [SerializeField] private GameObject barrel;

    private void Start()
    {
        float decimalChance = percentageChance / 100;

        decimalChance = Mathf.Clamp(decimalChance, 0, 1);

        if(decimalChance != 0)
        {
            int spawnID = Random.Range(1, (int)Mathf.Round(1 / decimalChance));

            if(spawnID == 1)
            {
                Instantiate(barrel, transform.position, transform.rotation);
            }

        }


        

        Destroy(this);

    }
}


