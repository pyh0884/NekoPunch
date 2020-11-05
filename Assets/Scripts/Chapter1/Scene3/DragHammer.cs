using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragHammer : Dragable
{
    public override void Interact()
    {
        FindObjectOfType<MoveCamera>().Move(new Vector3(0, -32.4f, 0));
    }
}
