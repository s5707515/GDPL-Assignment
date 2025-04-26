using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformParentOnDestroy : MonoBehaviour
{
    public void DecreaseValueInParent()
    {
        GetComponentInParent<CheckIfAllChildrenAreDestroyed>().DecreaseChildCount();
    }

    //This script might not be necessary.
}
