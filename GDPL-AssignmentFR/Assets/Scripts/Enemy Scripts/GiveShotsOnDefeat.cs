using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveShotsOnDefeat : MonoBehaviour
{
    [SerializeField] private int numberOfShots;

    private GameManager gameManagerScript;

    void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnDestroy() //Give the player more ammo when the object is destroyed
    {
        gameManagerScript.ChangeShots(numberOfShots);
    }

}
