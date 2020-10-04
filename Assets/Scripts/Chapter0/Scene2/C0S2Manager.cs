using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C0S2Manager : MonoBehaviour
{
    //public GameObject[] Items;
    public int stageIndex = 1;
    //public float timer;
    private MoveCamera moveCam;
    public bool finished;
    public int goodCount = 3;
    public int badCount = 3;
    void Start()
    {
        moveCam = FindObjectOfType<MoveCamera>();
        moveCam.Move(new Vector3(0, -21.6f, -10));
    }
    public void NextStage()
    {
        stageIndex += 1;
        //timer = 0.0f;
        finished = false;
    }
    void Update()
    {
        if (stageIndex != FindObjectOfType<StageHelper>().stageIndex) NextStage();
        switch (stageIndex)
        {
            //切屏到电脑交互界面时
            case 1:
                if (!finished)
                {
                    //if (goodCount == 2) 
                    //{
                    //    //动画
                    //}
                    //if (goodCount == 1)
                    //{
                    //    //动画
                    //}
                    //if (goodCount == 0)
                    //{
                    //    //动画
                    //}
                    if (goodCount + badCount == 0)
                    {
                        moveCam.Move(new Vector3(0, -32.4f, -10));
                        finished = true;
                    }
                }
                break;
            case 2:
                //播片就完事了
                if (!finished)
                {
                    Debug.Log("完事了");
                }
                break;
            default: break;
        }
    }
}
