using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfZone : Dragable
{
    public override void Interact()
    {
        GetComponent<FadeOutDestroy>().enabled = true;
        GetComponent<FadeOutDestroy>().isStart = true;
        FindObjectOfType<C0S2Manager>().badCount -= 1;
    }
}