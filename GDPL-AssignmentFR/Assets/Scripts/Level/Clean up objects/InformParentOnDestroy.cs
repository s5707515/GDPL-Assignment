using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformParentOnDestroy : MonoBehaviour
{
    public void DecreaseValueInParent()
    {
        GetComponentInParent<CheckIfAllChildrenAreDestroyed>().DecreaseChildCount();
    }

    //After condesing my code, this script might not be necessary... 0-0
}
