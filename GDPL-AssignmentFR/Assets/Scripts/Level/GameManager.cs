using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //store enemies in world, player shots and score here

    private int enemiesLeft = 10;

    [SerializeField] private int shotsLeft;

    private int score = 0;

    private bool lose = false;

    private bool win = false;

    [Header("Layout Spawnpoints")]

    [SerializeField] private Transform[] layoutSpawns;

    [Header("Layouts")]

    [SerializeField] private GameObject[] layouts;



    private void Start()
    {
        shotsLeft = 10;

        //Load layouts on Island

        for(int count = 0; count < layoutSpawns.Length; count++)
        {
            int rng = Random.Range(0, layouts.Length);

            Instantiate(layouts[rng], layoutSpawns[count].position, layoutSpawns[count].rotation);
        }
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

  
    public bool GetLose()
    {
        return lose;
    }    

    public bool GetWin()
    {
        return win;
    }

    public IEnumerator CheckForWinOrLose(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (enemiesLeft == 0)
        {
            win = true;

            Debug.Log("Time to win!");
        }
        else
        {
            if (shotsLeft == 0)
            {
                lose = true;

                Debug.Log("You Lose!");
            }
        }
    }
}
