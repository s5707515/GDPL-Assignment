using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfAllChildrenAreDestroyed : MonoBehaviour //Cleans up empty gameobjects left floating in void
{
    private int numChildren;
    private void Start()
    {
        numChildren = transform.childCount;
    }
    public void DecreaseChildCount()
    {
        numChildren--;

        if(numChildren <= 0)
        {
            Destroy(gameObject);
        }
    }
}
