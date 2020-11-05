using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class C0S2Manager : MonoBehaviour
{
    public GameObject[] Items;
    public int stageIndex = 1;
    public float timer;
    private MoveCamera moveCam;
    public bool finished;
    public int goodCount = 3;
    public int badCount = 3;
    void Start()
    {
        moveCam = FindObjectOfType<MoveCamera>();
        //moveCam.Move(new Vector3(0, -21.6f, -10));
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
                    if (goodCount == 2)
                    {
                        Items[0].SetActive(true);
                    }
                    if (goodCount == 1)
                    {
                        Items[0].GetComponent<Animator>().SetBool("Change1", true);
                    }
                    if (goodCount == 0)
                    {
                        Items[0].GetComponent<Animator>().SetBool("Change2", true);
                    }
                    if (goodCount + badCount == 0)
                    {
                        moveCam.Move(new Vector3(0, -32.4f, -10));
                        Destroy(Items[4]);
                        Destroy(Items[5]);
                        finished = true;
                    }
                }
                break;
            case 2:
                //猫猫看向兔兔镜头开始移动
                if (!finished)
                {
                    Items[1].transform.position = Vector3.MoveTowards
                        (Items[1].transform.position, new Vector3(6.5f, -32.4f, 0), 3 * Time.deltaTime);
                    Items[2].GetComponent<Animator>().SetBool("Turn", true);
                    if (Items[1].transform.position == new Vector3(6.5f, -32.4f, 0)) 
                    {
                        FindObjectOfType<StageHelper>().stageIndex += 1;
                        Items[3].GetComponent<Animator>().SetBool("Turn", true);
                        timer = 0;
                        Destroy(Items[6]);
                        finished = true;
                    }
                }
                break;
            case 3:
                //猫猫兔兔互看+傻笑
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer >= 1.0f)
                    {
                        Items[2].GetComponent<Animator>().SetTrigger("Change");
                        Items[3].GetComponent<Animator>().SetTrigger("Change");
                        FindObjectOfType<StageHelper>().stageIndex += 1;
                        finished = true;
                    }
                }
                break;
            case 4:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer >= 2.0f)
                    {
                        SceneManager.LoadScene(3);
                        finished = true;
                    }
                }
                break;
            default: break;
        }
    }
}
