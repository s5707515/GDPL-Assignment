using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowExplosionRadius : MonoBehaviour
{
    [SerializeField] private Explosive tnt;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(tnt.GetCentre().position, tnt.GetRadius());
    }
}
