using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyFallingObjects : MonoBehaviour
{
    [SerializeField] private LaunchBall launchBallScript;
    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Ball"))
        {
            if(collision.gameObject.GetComponent<InformParentOnDestroy>() != null) //if the object is a fragment of a breakable build
            {
                collision.gameObject.GetComponent<InformParentOnDestroy>().DecreaseValueInParent();
            }

            Destroy(collision.gameObject);
        }
        else
        {
            launchBallScript.HideBall();
        }
       
        
    }


}
