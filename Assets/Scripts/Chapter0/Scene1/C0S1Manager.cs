using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C0S1Manager : MonoBehaviour
{
    public GameObject[] Items;
    public GameObject[] Scenes;
    public int stageIndex = 1;
    public float trainLoopTime = 4.0f;
    public float gateOpenTime = 1.0f;
    public float timer;
    private MoveCamera moveCam;
    public bool finished;
    public float fadeSpeed = 10;
    [HideInInspector] public int PeopleCount = 6;
    private float alpha = 1;
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
            //地铁进站
            case 1:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer > trainLoopTime) 
                    {
                        //进站停车
                        Items[0].GetComponent<Animator>().SetBool("Loop", false);
                        finished = true;
                    }
                }
                break;
            //猫猫上车
            case 2:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer > gateOpenTime)
                    {
                        Items[2].GetComponent<Animator>().SetTrigger("Open");
                        Items[1].GetComponent<Cat1>().enabled = true;
                        finished = true;
                    }
                }
                break;
            //上车后
            case 3:
                if (!finished)
                {
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    alpha -= Time.deltaTime * fadeSpeed;
                    Items[1].GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    Items[2].GetComponent<Animator>().SetTrigger("Close");
                    Items[0].GetComponent<Animator>().SetBool("Loop", true);
                    timer += Time.deltaTime;
                    if (timer > 3.0f) 
                    {
                        moveCam.Move(new Vector3(0, -10.8f, -10));
                        alpha = 0;
                        finished = true;
                    }
                }
                break;
            //切换到火车内时
            case 4:
                if (!finished)
                {
                    Items[6].GetComponent<NamePlate>().enabled = true;
                    Items[7].GetComponent<NamePlate>().enabled = true;
                    Destroy(Scenes[0]);
                    finished = true;
                }
                break;
            //名牌切到徐家汇后
            case 5:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer > 1.0f)
                    {
                        moveCam.Move(new Vector3(0, -21.6f, -10));
                        finished = true;
                    }
                }
                break;
            //切换到下车分镜时
            case 6:
                if (!finished)
                {
                    Items[3].GetComponent<Animator>().enabled = true;
                    Destroy(Scenes[1]);
                    finished = true;
                }
                break;
            //地铁进站时
            case 7:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer > trainLoopTime)
                    {
                        //进站停车
                        Items[3].GetComponent<Animator>().SetBool("Loop", false);
                        finished = true;
                    }
                }
                break;
            //地铁开门
            case 8:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer > gateOpenTime)
                    {
                        Items[4].GetComponent<Animator>().SetTrigger("Open");
                        Items[5].GetComponent<Cat1>().enabled = true;
                        FindObjectOfType<StageHelper>().stageIndex += 1;
                        alpha = 0;
                        finished = true;
                    }
                }
                break;
            //猫猫走出来
            case 9:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    alpha += Time.deltaTime * fadeSpeed;
                    Items[5].GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    if (timer > gateOpenTime)
                    {
                        alpha = 1;
                        finished = true;
                    }
                }
                break;
            //切分镜到出地铁站
            case 10:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    alpha -= Time.deltaTime * fadeSpeed * 0.5f;
                    Items[5].GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    if (timer > 1.0f)
                    {
                        moveCam.Move(new Vector3(0, -32.4f, -10));
                        Destroy(Scenes[2], 2);
                        finished = true;
                    }
                }
                break;
            //扒拉人群
            case 11:
                if (!finished)
                {
                    Items[8].GetComponent<DragPeople1>().enabled = true;
                    Items[13].GetComponent<DragPeople1>().enabled = true;
                    Items[8].GetComponent<BoxCollider2D>().enabled = true;
                    Items[13].GetComponent<BoxCollider2D>().enabled = true;
                    if (PeopleCount == 4)
                    {
                        Items[9].GetComponent<DragPeople1>().enabled = true;
                        Items[12].GetComponent<DragPeople1>().enabled = true;
                        Items[9].GetComponent<BoxCollider2D>().enabled = true;
                        Items[12].GetComponent<BoxCollider2D>().enabled = true;
                    }
                    if (PeopleCount == 2)
                    {
                        Items[10].GetComponent<DragPeople1>().enabled = true;
                        Items[11].GetComponent<DragPeople1>().enabled = true;
                        Items[10].GetComponent<BoxCollider2D>().enabled = true;
                        Items[11].GetComponent<BoxCollider2D>().enabled = true;
                    }
                    if (PeopleCount == 0)
                    {
                        moveCam.Move(new Vector3(0, -43.2f, -10));
                        Destroy(Scenes[3], 2);
                        finished = true;
                    }
                }
                break;
            //看见狗狗
            case 12:
                //播片就完事了
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer > 2.0f)
                    {
                        moveCam.Move(new Vector3(0, -54.0f, -10));
                        FindObjectOfType<StageHelper>().stageIndex += 1;
                        alpha = 0;
                        finished = true;
                    }
                }
                break;
            case 13:
                //出现片头
                if (!finished)
                {
                    timer += Time.deltaTime;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    alpha += Time.deltaTime * fadeSpeed * .3f;
                    Items[14].GetComponent<Text>().color = new Color(1, 0, 0, alpha);
                    if (timer > 1.5f)
                    {
                        finished = true;
                    }
                }
                break;
            default:break;
        }
    }
}
