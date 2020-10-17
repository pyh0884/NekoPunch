using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : Dragable
{
    public GameObject[] items;
    public override void Interact()
    {
        foreach (GameObject go in items)
        {
            go.GetComponent<FadeOutDestroy>().enabled = true;
            go.GetComponent<FadeOutDestroy>().isStart = true;
        }
        FindObjectOfType<StageHelper>().stageIndex += 1;
    }
}
