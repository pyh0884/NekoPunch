using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragIcons : Dragable
{
    public GameObject target;
    public override void Interact()
    {
        GetComponent<FadeOutDestroy>().enabled = true;
        GetComponent<FadeOutDestroy>().isStart = true;
        target.GetComponent<FadeOutDestroy>().enabled = true;
        target.GetComponent<FadeOutDestroy>().isStart = true;
        FindObjectOfType<C0S4Manager>().IconCount -= 1;
    }
}
