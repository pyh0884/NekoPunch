using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{

    public void SelfDestroy() 
    {
        Destroy(gameObject);
    }
    public void PauseAnimation() 
    {
        GetComponent<Animator>().speed = 0.0f;
    }
    public void NextStage() 
    {
        FindObjectOfType<StageHelper>().stageIndex += 1;
    }

}
