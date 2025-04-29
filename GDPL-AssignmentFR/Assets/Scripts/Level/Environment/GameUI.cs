using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("Play UI References")]

    [SerializeField] private GameObject playUI;

    [SerializeField] private TextMeshProUGUI scoreTxt;

    [SerializeField] private TextMeshProUGUI shotsLeftTxt;

    [SerializeField] private TextMeshProUGUI rotationText;

    [SerializeField] private TextMeshProUGUI elevationText;

    [SerializeField] private TextMeshProUGUI powerText;

    [SerializeField] private TextMeshProUGUI enemiesRemainingText;

    [SerializeField] private TextMeshProUGUI timeSinceLaunchText;

    [SerializeField] private Image timeImage;

    [Header("Game Over Screen UI References")]

    [SerializeField] private GameObject gameOverScreenHolder;

    [SerializeField] private TextMeshProUGUI gameOverText;

    [SerializeField] private TextMeshProUGUI gameOverScore;

    [Header("Attributes")]

    [SerializeField] private int score;

    private AimCannon cannonScript;
    private GameManager gameManagerScript;

    bool showTime;

    public void Start()
    {
        cannonScript = GameObject.FindGameObjectWithTag("Cannon").GetComponent<AimCannon>(); 
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        gameOverScreenHolder.SetActive(false);
        playUI.SetActive(true);
    }
    public void Update()
    {
        //Update textMeshPros in real time

        scoreTxt.text = "Score: " + gameManagerScript.GetScore();

        shotsLeftTxt.text = "Shots Left: " + gameManagerScript.GetShotsLeft();

        rotationText.text = "R: " + cannonScript.GetRotation();
        elevationText.text = "E: " + cannonScript.GetElevation();
        powerText.text = "P: " + cannonScript.GetPower();

        enemiesRemainingText.text = "Enemies Remaining: " + gameManagerScript.GetRemainingEnemies();

        
        timeSinceLaunchText.text = cannonScript.GetTimeSinceLaunch().ToString();

        //Display Gameover screen on DEFEAT

        if (gameManagerScript.GetLose())
        {
            playUI.SetActive(false);
            gameOverScreenHolder.SetActive(true);

            gameOverScore.text = scoreTxt.text;
            gameOverText.text = "Game Over!";
        }


        //Display Gameover screen on VICTORY

        if (gameManagerScript.GetWin())
        {
            playUI.SetActive(false);
            gameOverScreenHolder.SetActive(true);

            gameOverScore.text = scoreTxt.text;

            gameOverText.text = "You Win!";
        }


    }

 

    public void ToggleTimeImage(bool activityLevel)
    {
        timeImage.gameObject.SetActive(activityLevel);
    }
   

}
