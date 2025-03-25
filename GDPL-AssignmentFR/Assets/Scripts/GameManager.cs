using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //store enemies in world, player shots and score here

    private int enemiesLeft;

    [SerializeField] private int shotsLeft;

    private int score = 0;

    private void Start()
    {
        shotsLeft = 10;
    }
    private void Update()
    {
        //Constantly work out how many enemy GameObjects are in the world

        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public int GetRemainingEnemies() 
    {
        return enemiesLeft;
    }

    public void ChangeShots(int _shotsleft)
    {
        shotsLeft += _shotsleft;
    }

    public int GetShotsLeft()
    {
        return shotsLeft;
    }

    public void IncrementScore(int _score)
    {
        score += _score;
    }

    public int GetScore()
    {
        return score;
    }
}
