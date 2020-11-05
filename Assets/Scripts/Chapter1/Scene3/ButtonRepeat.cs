using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRepeat : MonoBehaviour
{    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<StageHelper>().stageIndex += 1;
        }
    }
}
