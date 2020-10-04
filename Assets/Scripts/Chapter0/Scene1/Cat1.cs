using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat1 : Dragable
{
    public override void Interact()
    {
        FindObjectOfType<StageHelper>().stageIndex += 1;
    }
}
