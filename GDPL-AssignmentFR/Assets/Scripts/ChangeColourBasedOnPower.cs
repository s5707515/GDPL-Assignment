using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColourBasedOnPower : MonoBehaviour
{
    private LaunchBall launchBallScript;

    public float transition;

    [SerializeField] private Material mat;



    // Start is called before the first frame update
    void Start()
    {
        launchBallScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<LaunchBall>();
    }

    // Update is called once per frame
    void Update()
    {
        transition = (float)launchBallScript.GetPower() / (float)launchBallScript.GetMaxPower();

        
    }

    private void LateUpdate()
    {
        mat.color = Color.Lerp(new Color(255, 255, 0), new Color(255, 0, 0), transition);
    }
}
