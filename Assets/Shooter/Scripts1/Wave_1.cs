using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wave_1 : MonoBehaviour
{
    public float speed;
    public Transform[] pathPoints;
    void OnDrawGizmos()
    {
        DrawPath(pathPoints);
    }
    void DrawPath(Transform[] path)
    {
        if (path == null || path.Length < 2)
        {
            Debug.LogWarning("Path is not defined or has less than two points.");
            return;
        }
        Gizmos.color = Color.yellow; // Set the color for the path
        for (int i = 0; i < path.Length - 1; i++)
        {
            Gizmos.DrawLine(path[i].position, path[i + 1].position); // Draw lines between each point
        }
    }

}
