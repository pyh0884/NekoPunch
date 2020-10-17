using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DragIcons : Dragable
{
    public GameObject target;
    public GameObject background;
    public override void Interact()
    {
        GetComponent<FadeOutDestroy>().enabled = true;
        GetComponent<FadeOutDestroy>().isStart = true;
        target.GetComponent<FadeOutDestroy>().enabled = true;
        target.GetComponent<FadeOutDestroy>().isStart = true;
        Destroy(background);
        FindObjectOfType<C0S4Manager>().IconCount -= 1;
    }
}
