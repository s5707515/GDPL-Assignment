using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformParentOnDestroy : MonoBehaviour
{
    public void DecreaseValueInParent()
    {
        GetComponentInParent<CheckIfAllChildrenAreDestroyed>().DecreaseChildCount();
    }

    //After condesing my code, this script might be avoidable... 0-0
}
