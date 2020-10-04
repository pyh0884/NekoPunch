using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C0S4Manager : MonoBehaviour
{
    public GameObject[] Items;
    public int stageIndex = 1;
    public float timer;
    private MoveCamera moveCam;
    public bool finished;
    public int IconCount = 3;
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
            //接起电话时
            case 1:
                if (!finished)
                {
                    Items[0].GetComponent<Animator>().SetBool("Calling", true);
                    finished = true;
                }
                break;
            //妈妈出现时
            case 2:
                if (!finished)
                {
                    Items[1].gameObject.SetActive(true);
                    Items[2].gameObject.SetActive(true);
                    Items[3].gameObject.SetActive(true);
                    Items[4].gameObject.SetActive(true);
                    Items[5].gameObject.SetActive(true);
                    Items[6].gameObject.SetActive(true);
                    FindObjectOfType<StageHelper>().stageIndex += 1;
                    finished = true;
                }
                break;
            //通话中
            case 3:
                if (!finished)
                {
                    if (IconCount == 0) 
                    {
                        Items[0].GetComponent<Animator>().SetBool("Calling", false);
                        finished = true;
                    }
                }
                break;
            //挂电话后
            case 4:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer > 1.0f)
                    {
                        Destroy(Items[7]);
                        moveCam.Move(new Vector3(0, -10.8f, -10));
                        finished = true;
                    }
                }
                break;
            //切到门铃分镜
            case 5:
                if (!finished)
                {
                    finished = true;
                }
                break;
            default:break;
        }
    }
}
