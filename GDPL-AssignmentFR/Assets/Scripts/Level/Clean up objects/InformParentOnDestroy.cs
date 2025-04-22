using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformParentOnDestroy : MonoBehaviour
{
    
    private void OnDestroy()
    {
        GetComponentInParent<CheckIfAllChildrenAreDestroyed>().DecreaseChildCount();
    }
}
