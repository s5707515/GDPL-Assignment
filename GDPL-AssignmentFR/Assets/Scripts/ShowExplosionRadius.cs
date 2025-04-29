using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowExplosionRadius : MonoBehaviour
{
    [SerializeField] bool showRadius = true;
    [SerializeField] private Explosive tnt;
    private void OnDrawGizmos()
    {
        if (showRadius)
        {
            Gizmos.color = Color.red;

            Gizmos.DrawSphere(tnt.GetCentre().position, tnt.GetRadius());
        }
       
    }
}
