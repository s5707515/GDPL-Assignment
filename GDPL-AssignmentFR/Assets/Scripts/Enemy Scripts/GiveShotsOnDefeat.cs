using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveShotsOnDefeat : MonoBehaviour
{
    [SerializeField] private int numberOfShots;

    private GameUI gameUIScript;

    void Start()
    {
        gameUIScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GameUI>();
    }

    private void OnDestroy() //Give the player more ammo when the object is destroyed
    {
        gameUIScript.ChangeShots(numberOfShots);
    }

}
