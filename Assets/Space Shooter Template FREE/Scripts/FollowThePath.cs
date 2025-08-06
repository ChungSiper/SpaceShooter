using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Script này điều khiển kẻ địch (‘Enemy’) di chuyển theo một đường dẫn được xác định.
/// </summary>
public class FollowThePath : MonoBehaviour
{

    [HideInInspector] public Transform[] path; //Các điểm trên đường đi mà kẻ địch sẽ đi qua
    [HideInInspector] public float speed;
    [HideInInspector] public bool rotationByPath;   //Kẻ địch có xoay theo hướng của đường đi hay không
    [HideInInspector] public bool loop;         //Nếu loop là true, kẻ địch sẽ quay lại điểm bắt đầu sau khi hoàn thành đường đi
    float currentPathPercent;               //Phần trăm hoàn thành đường đi hiện tại
    Vector3[] pathPositions;                //Các điểm trên đường đi dưới dạng Vector3
    [HideInInspector] public bool movingIsActive;   //Kẻ địch có đang di chuyển hay không

    //Thiết lập các thông số đường đi cho kẻ địch và đưa kẻ địch đến điểm bắt đầu của đường đi
    public void SetPath()
    {
        currentPathPercent = 0;
        pathPositions = new Vector3[path.Length];       //Chuyển các điểm trên đường đi sang Vector3
        for (int i = 0; i < pathPositions.Length; i++)
        {
            pathPositions[i] = path[i].position;
        }
        transform.position = NewPositionByPath(pathPositions, 0); //Đưa kẻ địch đến điểm bắt đầu của đường đi
        if (!rotationByPath)
            transform.rotation = Quaternion.identity;
        movingIsActive = true;
    }

    private void Update()
    {
        if (movingIsActive)
        {
            currentPathPercent += speed / 100 * Time.deltaTime;     //Mỗi lần cập nhật, tính phần trăm đường đi đã hoàn thành dựa theo tốc độ

            transform.position = NewPositionByPath(pathPositions, currentPathPercent); //Di chuyển kẻ địch đến vị trí trên đường đi, tính bằng phương thức NewPositionByPath
            if (rotationByPath)                            //Xoay kẻ địch theo hướng của đường đi, nếu đã bật rotationByPath
            {
                transform.right = Interpolate(CreatePoints(pathPositions), currentPathPercent + 0.01f) - transform.position;
                transform.Rotate(Vector3.forward * 90);
            }
            if (currentPathPercent > 1)                    //Khi hoàn thành đường đi
            {
                if (loop)                                   //Nếu bật loop, quay lại điểm bắt đầu; nếu không, tiêu diệt hoặc vô hiệu hoá kẻ địch
                    currentPathPercent = 0;
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    Vector3 NewPositionByPath(Vector3[] pathPos, float percent)
    {
        return Interpolate(CreatePoints(pathPos), currentPathPercent);
    }

    Vector3 Interpolate(Vector3[] path, float t)
    {
        int numSections = path.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * numSections), numSections - 1);
        float u = t * numSections - currPt;
        Vector3 a = path[currPt];
        Vector3 b = path[currPt + 1];
        Vector3 c = path[currPt + 2];
        Vector3 d = path[currPt + 3];
        return 0.5f * ((-a + 3f * b - 3f * c + d) * (u * u * u) + (2f * a - 5f * b + 4f * c - d) * (u * u) + (-a + c) * u + 2f * b);
    }

    Vector3[] CreatePoints(Vector3[] path)
    {
        Vector3[] pathPositions;
        Vector3[] newPathPos;
        int dist = 2;
        pathPositions = path;
        newPathPos = new Vector3[pathPositions.Length + dist];
        Array.Copy(pathPositions, 0, newPathPos, 1, pathPositions.Length);
        newPathPos[0] = newPathPos[1] + (newPathPos[1] - newPathPos[2]);
        newPathPos[newPathPos.Length - 1] = newPathPos[newPathPos.Length - 2] + (newPathPos[newPathPos.Length - 2] - newPathPos[newPathPos.Length - 3]);
        if (newPathPos[1] == newPathPos[newPathPos.Length - 2])
        {
            Vector3[] LoopSpline = new Vector3[newPathPos.Length];
            Array.Copy(newPathPos, LoopSpline, newPathPos.Length);
            LoopSpline[0] = LoopSpline[LoopSpline.Length - 3];
            LoopSpline[LoopSpline.Length - 1] = LoopSpline[2];
            newPathPos = new Vector3[LoopSpline.Length];
            Array.Copy(LoopSpline, newPathPos, LoopSpline.Length);
        }
        return (newPathPos);
    }
}
