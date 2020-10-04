using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamePlate : Dragable
{
    public GameObject nextPlate;
    public override void Interact()
    {
        if (nextPlate)
        {
            nextPlate.SetActive(true);
            Destroy(gameObject);
        }
        else
        {
            FindObjectOfType<StageHelper>().stageIndex += 1;
        }
    }
}
