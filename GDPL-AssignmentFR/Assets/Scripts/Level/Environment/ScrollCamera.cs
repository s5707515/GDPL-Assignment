using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCamera : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freeLookCam;

    [SerializeField] float scrollSpeed = 10;

    [SerializeField] float FOV;

    [SerializeField] float minFOV = 30;
    [SerializeField] float maxFOV = 120;

    bool shiftUp = true;

    private void Update()
    {
        //Change the FOV of the camera by using the scroll wheel ONLY when SHIFT is UP

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            shiftUp = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            shiftUp = true;
        }

       
        if (shiftUp) //Change FOV based on Mouse Scrollwheel movement
        {
            FOV = freeLookCam.m_Lens.FieldOfView;
            freeLookCam.m_Lens.FieldOfView = Mathf.Clamp(FOV - Input.GetAxis("Mouse ScrollWheel") * scrollSpeed, minFOV, maxFOV);
        }

    }
}
