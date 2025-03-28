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

    [SerializeField] private TextMeshProUGUI powerText;

    [SerializeField] private TextMeshProUGUI enemiesRemainingText;

    [SerializeField] private TextMeshProUGUI timeSinceLaunchText;

    [SerializeField] private Image timeImage;

    [Header("Attributes")]

    [SerializeField] private int score;

    private LaunchBall launchBallScript;
    private GameManager gameManagerScript;

    bool showTime;

    public void Start()
    {
        launchBallScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<LaunchBall>(); 
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    public void Update()
    {
        scoreTxt.text = "Score: " + gameManagerScript.GetScore();

        shotsLeftTxt.text = "Shots Left: " + gameManagerScript.GetShotsLeft();

        rotationText.text = "R: " + launchBallScript.GetRotation();
        elevationText.text = "E: " + launchBallScript.GetElevation();
        powerText.text = "P: " + launchBallScript.GetPower();

        enemiesRemainingText.text = "Enemies Remaining: " + gameManagerScript.GetRemainingEnemies();

        
        timeSinceLaunchText.text = launchBallScript.GetTimeSinceLaunch().ToString();

    }

    public void ToggleTimeImage(bool activityLevel)
    {
        timeImage.gameObject.SetActive(activityLevel);
    }
   

}
