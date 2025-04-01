using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    [Header("Ball Attributes")]

   
    [SerializeField] private float power;

    

   
    [SerializeField] private float maxPower;
    
   
    [SerializeField] private float rotationSpeed;

    [Header("References")]

    [SerializeField] private Transform spawnPos;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject arrow;

    private GameManager gameManagerScript;
    private GameUI UIscript;

   

    [Header("Time")]

    [SerializeField] private float timeSinceLaunch;

    [SerializeField] private float maxLaunchTime = 10f;


    private float yTilt;
    private float zTilt;
    private float powerChange;

    private float elevation;
    private float rotation;

    private bool inAir = false;


    private void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        UIscript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GameUI>();

        //ENSURE ball is not moving at start

        rb.velocity = Vector3.zero;  
        rb.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        //Launch the ball when SPACE is pressed, the ball has not already been launched and the player still has shots left

        if (Input.GetKeyDown(KeyCode.Space) && !inAir && gameManagerScript.GetShotsLeft() > 0)
        {
            arrow.SetActive(false); // Remove trajectory arrow


            rb.velocity = -transform.right * power;

            inAir = true;

            gameManagerScript.ChangeShots(-1);
            UIscript.ToggleTimeImage(true);

        }

        //Increment the launch time whilst in the air

        if (inAir)
        {
            timeSinceLaunch += Time.deltaTime;
        }

        //Respawn ball when it reaches time limit

        if (timeSinceLaunch > maxLaunchTime)
        {
            RespawnBall();
        }


        //Change angle of launch by pressing A and D

        yTilt = Input.GetAxis("Horizontal") * rotationSpeed * 10 * Time.deltaTime;

        //Change Elevation of the ball by pressing W and S

        zTilt = Input.GetAxis("Vertical") * rotationSpeed * 10 * Time.deltaTime;


        //Change power of the ball using scroll wheel

        powerChange = Input.GetAxis("Mouse ScrollWheel") * 10;

        if (gameObject.transform.position.y < -20) // Respawn ball if it falls off the map
        {
            RespawnBall();
        }
    }

   

    private void LateUpdate()
    {
        
        //Lock rotation of object accordingly

        rotation = Mathf.Clamp(rotation + yTilt, -90, 90);
        elevation = Mathf.Clamp(elevation + zTilt, -90, 0);
        

        //Change rotation of object

        transform.rotation = Quaternion.Euler(0, rotation, elevation);

        //Change power of object

        power = Mathf.Clamp(power + powerChange, 0, maxPower);
    }

    
    public void RespawnBall() //Sends the ball back to it's spawnpoint after a specific amount of time
    {
        rb.isKinematic = true;

        //Reset transform properties

        gameObject.transform.position = spawnPos.position;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        rotation = 0;
        elevation = 0;

        timeSinceLaunch = 0;
        inAir = false;
        arrow.SetActive(true);

        rb.isKinematic = false;

        UIscript.ToggleTimeImage(false);

        StartCoroutine(gameManagerScript.CheckForWinOrLose(0.1f));

    }

   










    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            RespawnBall();
        }
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
        return Mathf.Round(timeSinceLaunch * 10) * 0.1f;
    }
}

