using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;

public class AimCannon : MonoBehaviour
{
    [Header("Cannon Attributes")]

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float power;

    [SerializeField] private float maxPower;

    [Header("Cannon Parts")]

    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject entireCannon;


    [SerializeField] private Transform smokeSpawn;
    [SerializeField] private GameObject smokePrefab;

    [Header("References")]

    [SerializeField] private GameManager gameManagerScript;
    [SerializeField] private GameUI UIScript;
    [SerializeField] private LaunchBall launchBallScript;

    [SerializeField] private GameObject arrow;

    [Header("Projectile Time Factors")]


    [SerializeField] private float timeSinceLaunch;

    [SerializeField] private float maxLaunchTime = 10f;

    

   


    bool projectileFired = false;

    //Cannon Variables (REP)

    private float yTilt;
    private float zTilt;
    private float powerChange;

    private float elevation;
    private float rotation;

    private bool shiftDown = false;


    private void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        //Launch a ball when space is pressed

        if(Input.GetKeyDown(KeyCode.Space) && gameManagerScript.GetShotsLeft() > 0 && !projectileFired)
        {
            FireCannon();
        }

        //Increment time whilst the projectile is being launched


        if (projectileFired)
        {
            timeSinceLaunch += Time.deltaTime;
        }

        //Hide projectile after time limit expires

        if(timeSinceLaunch > maxLaunchTime)
        {
            launchBallScript.HideBall();
        }


        //Change angle of launch by pressing A and D

        yTilt = Input.GetAxis("Horizontal") * rotationSpeed * 5 * Time.deltaTime;

        //Change Elevation of the ball by pressing W and S

        zTilt = Input.GetAxis("Vertical") * rotationSpeed * 5 * Time.deltaTime;


        //Change power of the ball using SHIFT scroll wheel

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            shiftDown = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            shiftDown = false;
        }

        if (shiftDown)
        {
            powerChange = Input.GetAxis("Mouse ScrollWheel") * 10;
        }
    }

    private void LateUpdate()
    {

        //Lock rotation of object accordingly

        rotation = Mathf.Clamp(rotation + yTilt, -90, 90);
        elevation = Mathf.Clamp(elevation + zTilt, -90, 0);


        //Change rotation of object

        cannon.transform.rotation = Quaternion.Euler(0, rotation, elevation);
        entireCannon.transform.rotation = Quaternion.Euler(0, rotation, 0);

        //Change power of object

        power = Mathf.Clamp(power + powerChange, 0, maxPower);
    }

    private void FireCannon() //Fire a ball from the cannon with correct trajectory
    {
        arrow.SetActive(false); // Remove trajectory arrow

        // Get the Y rotation of the cannon stand 
        float yRotation = entireCannon.transform.rotation.eulerAngles.y;

        // Get the Z rotation of the aimable part
        float zRotation = cannon.transform.rotation.eulerAngles.z;

        launchBallScript.FireBall(Quaternion.Euler(0, yRotation, zRotation), power);

        projectileFired = true;

        gameManagerScript.ChangeShots(-1); //Update UI

        UIScript.ToggleTimeImage(true);

        //Spawn smoke at mouth of cannon
        Instantiate(smokePrefab,smokeSpawn.position, smokeSpawn.rotation);
    }

    public void ResetCannon() //Reset the game back to aiming phase (called when the ball is hidden)
    {
        rotation = 0;
        elevation = 0;

        timeSinceLaunch = 0;

        projectileFired = false;

        arrow.SetActive(true);

        UIScript.ToggleTimeImage(false);

        StartCoroutine(gameManagerScript.CheckForWinOrLose(0.1f));
    }


    public int GetRotation()
    {
        return (int)rotation;
    }

    public int GetElevation()
    {
        return Mathf.Abs((int)elevation);
    }

    public int GetPower()
    {
        //Return power to 1dp

        return (int)power;
    }

    public float GetMaxPower()
    {
        return maxPower;
    }

    public float GetTimeSinceLaunch()
    {
        return Mathf.Round(timeSinceLaunch * 10f) / 10f;
    }
}  
