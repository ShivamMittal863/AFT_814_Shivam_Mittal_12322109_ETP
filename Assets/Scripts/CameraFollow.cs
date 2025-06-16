using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        transform.position = desiredPosition;
    }
}
