using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : Dragable
{
    public override void Interact()
    {
        GetComponentInChildren<MoveCamera>().enabled = true;
    }
}