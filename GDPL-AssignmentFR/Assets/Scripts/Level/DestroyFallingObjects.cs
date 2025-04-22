using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyFallingObjects : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject); 
        }
    }


}
