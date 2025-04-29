using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorGizmos : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireCube(transform.position,transform.localScale);
    }
}
