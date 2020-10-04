using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C0S3Manager : MonoBehaviour
{
    public int stageIndex = 0;
    public float timer;
    private MoveCamera moveCam;
    public bool finished;
    public int goodCount = 3;
    void Start()
    {
        moveCam = FindObjectOfType<MoveCamera>();
    }
    public void NextStage()
    {
        stageIndex += 1;
        timer = 0.0f;
        finished = false;
    }
    void Update()
    {
        if (stageIndex != FindObjectOfType<StageHelper>().stageIndex) NextStage();
        switch (stageIndex)
        {
            case 0:
                if (!finished)
                {
                    if (goodCount == 0)
                    {
                        FindObjectOfType<StageHelper>().stageIndex += 1;
                        finished = true;
                    }
                }
                break;
            case 1:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer > 1.0f)
                    {
                        moveCam.Move(new Vector3(0, -10.8f, -10));
                        finished = true;
                    }
                }
                break;
            default: break;
        }
    }
}
