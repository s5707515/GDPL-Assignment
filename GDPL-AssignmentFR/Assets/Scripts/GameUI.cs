using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("Canvas References")]

    [SerializeField] private TextMeshProUGUI scoreTxt;

    [SerializeField] private TextMeshProUGUI shotsLeftTxt;

    [SerializeField] private TextMeshProUGUI rotationText;

    [SerializeField] private TextMeshProUGUI elevationText;

    [SerializeField] private TextMeshProUGUI enemiesRemainingText;

    [Header("Attributes")]

    [SerializeField] private int score;
    [SerializeField] private int shotsLeft;

    private LaunchBall launchBallScript;
    private GameManager gameManagerScript;

    public void Start()
    {
        launchBallScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<LaunchBall>(); 
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        shotsLeft = 10;
    }
    public void Update()
    {
        scoreTxt.text = "Score: " + score;

        shotsLeftTxt.text = "Shots Left: " + shotsLeft;

        rotationText.text = "R: " + launchBallScript.GetRotation();
        elevationText.text = "E: " + launchBallScript.GetElevation();
        enemiesRemainingText.text = "Enemies Remaining: " + gameManagerScript.GetRemainingEnemies(); 
    }
    public void IncrementScore(int _score)
    {
        score += _score;
    }

    public void ChangeShots(int _shotsleft)
    {
        shotsLeft += _shotsleft;
    }

    public int GetShotsLeft()
    {
        return shotsLeft;
    }
}
