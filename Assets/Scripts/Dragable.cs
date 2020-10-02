using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    #region parameters
    private Vector3 startPoint;     //起点位置
    [Header("目标位置")]
    public Vector3 goalPoint;
    [Header("是否允许拖动超过目标点")]
    public bool allowOverDrag;
    [Header("自动移动到目标点的速度")]
    public float autoMoveSpeed = 1.0f;
    private bool isAuto;
    [Header("是否需要精确落在目标点")]
    public bool isPrecise;
    [Header("目标判定点半径")]
    public float goalRadius = 1.0f;
    [Header("是否只在一条坐标轴上移动")]
    public bool moveInOneAxis = false;
    [Header("是否只考虑横向位置")]
    public bool isHorizontal = true;
    [Header("是否只考虑纵向位置")]
    public bool isVertical = false;
    [Header("是否滑向坐标正方向")]
    public bool positiveDirection = true;
    [Header("松手后是否移回起点位置")]
    public bool ifMoveBack = true;
    [Header("移回速度，0表示瞬间移回")]
    public float moveBackSpeed = 5;
    [Header("是否根据距离改变尺寸")]
    public bool ifScaleChange = false;
    [Header("移动到目标点时的尺寸")]
    public float targetScale;
    private float distance;         //起点与终点间的距离
    private Vector3 mousePosition;
    private Vector3 clickPoint;
    [Header("该物体是否正在被拖动")]
    public bool isMoving = false;
    [Header("该物体是否已到达目标点")]
    public bool isFinished = false;
    [Header("靠近目标点的百分比")]
    public float ratio;
    #endregion
    private void Start()
    {
        startPoint = transform.position;
        distance = (goalPoint - startPoint).magnitude;
    }

    //判断落点是否满足给定的条件
    private bool isNearEnough() 
    {
        if (isPrecise)
        {
            return (Mathf.Abs(transform.position.x - goalPoint.x) < goalRadius
                    && Mathf.Abs(transform.position.y - goalPoint.y) < goalRadius);
        }
        else if (isHorizontal)
        {
            if (positiveDirection) return transform.position.x > goalPoint.x;
            else return transform.position.x < goalPoint.x;
        }
        else if (isVertical)
        {
            if (positiveDirection) return transform.position.y > goalPoint.y;
            else return transform.position.y < goalPoint.y;
        }
        return false;
    }

    //在继承Dragable的类中复写
    virtual public void Interact() {}

    private void Update()
    {
        if (isFinished) return;
        //移动到目标点时自动交互
        if (!allowOverDrag && isNearEnough()) isAuto = true;
        if (isMoving && !isAuto) 
        {
            //移动GameObject
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.localPosition = new Vector3(mousePosition.x - startPoint.localPosition.x, mousePosition.y - startPoint.localPosition.y, 0);
            Vector3 displacement = new Vector3(mousePosition.x - clickPoint.x, mousePosition.y - clickPoint.y, 0); 
            if (moveInOneAxis)
            {
                if (isHorizontal)
                {
                    displacement = new Vector3(mousePosition.x - clickPoint.x, 0, 0);
                }
                else if (isVertical)
                {
                    displacement = new Vector3(0, mousePosition.y - clickPoint.y, 0);
                }
            }
            transform.position = startPoint + displacement;
        }
        else
        {
            //回到原点
            if (ifMoveBack && !isAuto && !isFinished)
            {
                if (moveBackSpeed != 0.0f)
                {
                    //transform.position = Vector3.Lerp(transform.position, startPoint, moveBackSpeed * Time.deltaTime);
                    transform.position = Vector3.MoveTowards(transform.position, startPoint, moveBackSpeed * Time.deltaTime);
                }
                else transform.position = startPoint;
            }
            if (isAuto) 
            {
                transform.position = Vector3.MoveTowards(transform.position, goalPoint, autoMoveSpeed * Time.deltaTime);
                if (transform.position == goalPoint) 
                {
                    Interact();
                    isAuto = false;
                    isFinished = true;
                }
            }
        }
        //根据距离缩放
        if (ifScaleChange)
        {
            float currentDist = (transform.position - goalPoint).magnitude;
            if (currentDist < distance)
            {
                ratio = 1 - currentDist / distance;
                float currentScale = targetScale >= 1 ? 1 + ratio * (targetScale - 1) : 1 - ratio * (1 - targetScale);
                transform.localScale = new Vector3(currentScale, currentScale, 1);
            }
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !isAuto && !isFinished)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPoint = mousePosition;
            isMoving = true;
        }
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0) && !isAuto && !isFinished)
        {
            isMoving = false;
            //判断是否完成目标
            if (isNearEnough())
            {
                isAuto = true;
            }
        }
    }
}