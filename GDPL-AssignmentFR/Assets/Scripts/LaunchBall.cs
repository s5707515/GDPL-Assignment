using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    [Header("Ball Attributes")]

    [SerializeField] private float power;
    
   
    [SerializeField] private float rotationSpeed;

    [Header("References")]

    [SerializeField] private Transform spawnPos;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject arrow;

    private GameUI gameUIScript;

    private float elevation;
    private float rotation;
    
    private bool inAir = false;

    private void Start()
    {
        gameUIScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GameUI>();

        //ENSURE ball is not moving at start

        rb.velocity = Vector3.zero;  
        rb.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        //Launch the ball when SPACE is pressed, the ball has not already been launched and the player still has shots left

        if(Input.GetKeyDown(KeyCode.Space) && !inAir && gameUIScript.GetShotsLeft() > 0)
        {
            arrow.SetActive(false); // Remove trajectory arrow

            
            rb.velocity =  transform.forward * power;

            inAir = true;

            gameUIScript.ChangeShots(-1);
        }

        //Chnage angle of launch by pressing A and D

        rotation = Input.GetAxis("Horizontal") * rotationSpeed * 10  * Time.deltaTime;


        //Change Elevation of the ball by pressing W and S

        elevation = Input.GetAxis("Vertical") * rotationSpeed * 10 * Time.deltaTime;


        if(gameObject.transform.position.y < -20 ) // Respawn ball if it falls off the map
        {
            RespawnBall();
        }
    }

    private void LateUpdate()
    {
        //Change rotation of object

        transform.Rotate(elevation, rotation, 0);
    }

    public void RespawnBall() //Sends the ball back to it's spawnpoint
    {
        rb.isKinematic = true;

        gameObject.transform.position = spawnPos.position;
        gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);

        inAir = false;
        arrow.SetActive(true);
        rb.isKinematic = false;

    }
}
