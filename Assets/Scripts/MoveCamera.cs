using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [HideInInspector]public Vector3 targetPosition;
    public float moveSpeed = 3.0f;
    private bool isMoving;
    public void Move(Vector3 targetPos)
    {
        targetPosition = targetPos;
        targetPosition.z = -10;
        isMoving = true;
    }
    private void LateUpdate()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition) isMoving = false;
        }  
    }
}
