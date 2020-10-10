using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class DragCamera : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    private Vector3 targetPosition;
    public float moveSpeed = 3.0f;
    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y > 0) 
        {
            targetPosition.y += Time.deltaTime * moveSpeed;
            targetPosition.y = Mathf.Clamp(targetPosition.y, endPosition.y, startPosition.y);
            transform.position = targetPosition;
            if (transform.position == endPosition)
            {
                FindObjectOfType<StageHelper>().stageIndex += 1;
                this.enabled = false;
            }
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            targetPosition.y -= Time.deltaTime * moveSpeed;
            targetPosition.y = Mathf.Clamp(targetPosition.y, endPosition.y, startPosition.y);
            transform.position = targetPosition;
            if (transform.position == endPosition)
            {
                FindObjectOfType<StageHelper>().stageIndex += 1;
                this.enabled = false;
            }
        }
    }
}