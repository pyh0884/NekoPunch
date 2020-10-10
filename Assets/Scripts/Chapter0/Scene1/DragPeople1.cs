using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPeople1 : Dragable
{
    public override void Interact()
    {
        GetComponent<FadeOutDestroy>().isStart = true;
        FindObjectOfType<C0S1Manager>().PeopleCount -= 1;
    }
}
