using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : Dragable
{
    public override void Interact()
    {
        GetComponent<FadeOutDestroy>().enabled = true;
        GetComponent<FadeOutDestroy>().isStart = true;
        FindObjectOfType<C0S3Manager>().goodCount -= 1;
    }
}
