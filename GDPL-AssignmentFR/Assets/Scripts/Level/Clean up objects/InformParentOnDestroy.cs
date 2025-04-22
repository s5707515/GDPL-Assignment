using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformParentOnDestroy : MonoBehaviour
{
    bool quitting = false;

    private void Start()
    {
        quitting = false;
    }
    private void OnDestroy()
    {
        if(!quitting) //Avoid error where OnDestroy is trying to find a parent during quit
        {
            GetComponentInParent<CheckIfAllChildrenAreDestroyed>().DecreaseChildCount();
        }
        
    }

    private void OnApplicationQuit()
    {
        quitting = true;
    }
}
