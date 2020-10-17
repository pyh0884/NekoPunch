using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Dragable
{
    public override void Interact()
    {
        FindObjectOfType<StageHelper>().stageIndex += 1;
    }
}
