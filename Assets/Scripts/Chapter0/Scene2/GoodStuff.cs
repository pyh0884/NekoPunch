using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodStuff : Dragable
{
    public override void Interact()
    {
        GetComponent<FadeOutDestroy>().enabled = true;
        GetComponent<FadeOutDestroy>().isStart = true;
        FindObjectOfType<C0S2Manager>().goodCount -= 1;
    }
}
