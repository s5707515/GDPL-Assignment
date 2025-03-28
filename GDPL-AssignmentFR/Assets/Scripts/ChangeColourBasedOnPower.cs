using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColourBasedOnPower : MonoBehaviour
{
    private LaunchBall launchBallScript;

    public float transition;

    [SerializeField] public Material mat;

    public Color lowColour;

    public Color highColour;



    // Start is called before the first frame update
    void Start()
    {
        launchBallScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<LaunchBall>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transition = Mathf.Clamp01((float)launchBallScript.GetPower() / (float)launchBallScript.GetMaxPower());

        mat.color = Color.Lerp(lowColour , highColour, transition);

    }
}

