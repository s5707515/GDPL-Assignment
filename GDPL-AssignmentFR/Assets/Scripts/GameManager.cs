using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int enemiesLeft;
    private void Update()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public int GetRemainingEnemies()
    {
        return enemiesLeft;
    }
}
