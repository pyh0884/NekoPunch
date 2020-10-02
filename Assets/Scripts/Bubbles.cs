using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : Dragable
{
    public Vector3 nextScenePosition;
    override public void Interact()
    {
        //transform.position = goalPoint;
        FindObjectOfType<MoveCamera>().Move(nextScenePosition);
    }
}
