using System.Collections;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
