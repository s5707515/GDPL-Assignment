using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    [SerializeField] private GameObject ball;


    void LateUpdate() //Keeps the camera a set distance away from the ball
    {
        transform.position = ball.transform.position + offset;
    }
}
