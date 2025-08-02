using UnityEditor;
using UnityEngine;

public class WaveEnemy : MonoBehaviour
{
    public GameObject enemy;

    public int count;

    public float speed;

    public float timeBetween;

    public Transform[] pathPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnDrawGizmos()
    {
        Vector3[] pathPositionS = new Vector3[4];
        Gizmos.color = Color.yellow;
        Handles.Label(transform.position, "Some text");
        for (int i = 0; i < pathPoint.Length - 1; i++)
        {
            Gizmos.DrawLine(pathPoint[i].transform.position, pathPoint[i + 1].transform.position);
        }
        // Update is called once per frame
    }
}
