using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [Header("Canvas References")]

    [SerializeField] private TextMeshProUGUI scoreTxt;

    [SerializeField] private TextMeshProUGUI shotsLeftTxt;

    [Header("Attributes")]

    [SerializeField] private int score;
    [SerializeField] private int shotsLeft;

    public void Start()
    {
        shotsLeft = 10;
    }
    public void Update()
    {
        scoreTxt.text = "Score: " + score;

        shotsLeftTxt.text = "Shots Left: " + shotsLeft;
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
