using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPaw : Dragable
{
    public override void Interact()
    {
        FindObjectOfType<StageHelper>().stageIndex += 1;
    }
}
