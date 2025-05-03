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

        //Load enemy layouts on Island

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
   


    public int GetRemainingEnemies() //Used by the UI
    {
        return enemiesLeft;
    }

    public void ChangeShots(int _shotsleft) //Used by AimCannon are firing a shot
    {
        shotsLeft += _shotsleft;
    }

    public int GetShotsLeft()//Used by the UI
    {
        return shotsLeft;
    }

    public void IncrementScore(int _score) //Called by Enemies on defeat
    {
        score += _score;
    }

    public int GetScore()//Used by the UI
    {
        return score;
    }

  
    public bool GetLose()//Used by the UI
    {
        return lose;
    }    

    public bool GetWin()//Used by the UI
    {
        return win;
    }

    public IEnumerator CheckForWinOrLose(float delay)//Called by AimCannon after each shot has finished
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
