using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Vector3 currentPosition;
    [HideInInspector]public Vector3 targetPosition;
    private float targetSize;
    public float moveSpeed = 3.0f;
    private bool isMoving;
    private bool isZooming;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        currentPosition = transform.position;
        targetSize = 5.4f;
    }
    public void Move(Vector3 targetPos)
    {
        targetPosition = targetPos;
        currentPosition = targetPos;
        targetPosition.z = -10;
        isMoving = true;
    }
    public void InstantMove(Vector3 targetPos) 
    {
        targetPosition = targetPos;
        currentPosition = targetPos;
        targetPosition.z = -10;
        transform.position = targetPosition;
        FindObjectOfType<StageHelper>().stageIndex += 1;
    }
    public void ZoomIn(float targetSize, Vector3 targetPos) 
    {
        isZooming = true;
        this.targetSize = targetSize;
        this.targetPosition = targetPos;
    }
    public void ZoomOut()
    {
        this.targetPosition = currentPosition;
        targetSize = 5.4f;
        isZooming = true;
    }
    private void LateUpdate()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                isMoving = false;
                FindObjectOfType<StageHelper>().stageIndex += 1;
            }
        }
        if (isZooming)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                isZooming = false;
                FindObjectOfType<StageHelper>().stageIndex += 1;
            }
        }
    }
}
