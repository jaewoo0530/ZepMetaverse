using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraLobby : MonoBehaviour
{
    public Transform target;

    float maxX = 25;
    float maxY = 25;
    float minX = -25;
    float minY = -25;

    void Start()
    {
        if (target == null)
            return;
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y;

        if(pos.x > maxX - 12) pos.x = maxX - 12;
        if(pos.y > maxY - 6) pos.y = maxY - 6;
        if(pos.x < minX + 12) pos.x = minX + 12;
        if(pos.y < minY + 6) pos.y = minY + 6;
        transform.position = pos;
    }
}
